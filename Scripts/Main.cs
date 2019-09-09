using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class Main : MonoBehaviour {

    // Use this for initialization

    GameObject g;
    KeywordRecognizer listener;
    private GameObject gameOverBoard;

    string[] words = { CommandWords.DUCK, CommandWords.JUMP, CommandWords.YELLOW, CommandWords.RED, CommandWords.PINK, CommandWords.PURPLE, CommandWords.BROWN };
    Player playerScript;
    List<Sprite> groundSprites = new List<Sprite>();
    List<Sprite> cloudSprites = new List<Sprite>();
    List<Sprite> bushSprites = new List<Sprite>();
    Animator airPlane;
    TextMesh scoreText;
    Dictionary<string, Color> colorMap = new Dictionary<string, Color>();
    int highScore;

    void Start() {
        PlayerPrefs.DeleteAll();
        gameOverBoard = GameObject.Find(CommandWords.GAMEOVERBOARD);

        loadSprites("Ground", 4, groundSprites);
        loadSprites("Cloud", 3, cloudSprites);
        loadSprites("Bush", 3, bushSprites);

        g = GameObject.Find(CommandWords.PLAYEROBJECT);
        playerScript = g.GetComponent<Player>();
        airPlane = GameObject.Find("Airplane").GetComponent<Animator>();
        scoreText = GameObject.Find("ScoreObject").GetComponent<TextMesh>();

        float[] positions = { -3.5f, 7.75f, 19 };
        foreach (float positionX in positions)
        {
            GameObjectCreator.createSprite(new Vector2(positionX, -2.9f), groundSprites[0], true);
        }

        listener = new KeywordRecognizer(words);
        listener.OnPhraseRecognized += recognize;
        listener.Start();
        colorMap.Add(CommandWords.YELLOW, Color.yellow);
        colorMap.Add(CommandWords.RED, Color.red);
        colorMap.Add(CommandWords.PURPLE, Color.magenta);
        colorMap.Add(CommandWords.PINK, new Color(1, 0, 0.5f));
        colorMap.Add(CommandWords.BROWN, new Color(0.56f, 0.43f, 0.3f));

        highScore = PlayerPrefs.GetInt(CommandWords.HIGHSCORE + "1", 0);
    }

    void recognize(PhraseRecognizedEventArgs args)
    {
        string command = args.text;
        Debug.Log(args.text);

        if (command == CommandWords.JUMP)
        {
            playerScript.jump();
        }
        else if (command == CommandWords.DUCK)
        {
            playerScript.duck();
        }
        else
        {
            Color c = colorMap[command];
            g.transform.GetComponent<SpriteRenderer>().color = colorMap[command];
        }
    }


    int timer = 0;
    int spawnObstacleTimer = 0;
    int cloudSpawnTimer = 50;
    int score = 0;
    bool isPlaying = false;
    // Update is called once per frame
    void Update() {
        timer++;
        if (!listener.IsRunning)
        {
            Debug.Log("Listener stopped running");
        }
        if(timer % 200 == 0 && isPlaying)
        {
            updateScore(true);
        }

        if (timer % 112 == 0)
        {
            spawnGround();
        }
        if (timer == cloudSpawnTimer)
        {
            spawnCloud();
        }

        if (timer == spawnObstacleTimer && isPlaying)
        {
            spawnObstacle();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerScript.jump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerScript.duck();
        }
    }

    private void spawnObstacle()
    {
        int action = Random.Range(0, 4);
        if (action == 3)
        {
            airPlane.SetTrigger("AIRPLANE");
            spawnObstacleTimer += 500;
        }
        else
        {
            int amountOfObstacles = Random.Range(1, 3);
            for (int i = 0; i < amountOfObstacles; i++)
            {
                GameObject g = GameObjectCreator.createSprite(new Vector2(10 + i * 2, -1.83f), bushSprites[action], true);
                Rigidbody2D body = g.AddComponent<Rigidbody2D>();
                body.isKinematic = true;
                g.AddComponent<BoxCollider2D>();
            }
            spawnObstacleTimer += Random.Range(150, 250);
        }
    }

    private void updateScore(bool increaseScore)
    {
        if (increaseScore)
        {
            score++;
        }
        string text = "";
        if (score < 10)
        {
            text = "00" + score;
        }
        else if (score < 100)
        {
            text = "0" + score;
        }
        else
        {
            text = score.ToString();
        }
        scoreText.text = text;
    }

    private void spawnCloud()
    {
        GameObjectCreator.createSprite(new Vector2(19f, 2.5f), cloudSprites[Random.Range(0, 3)], true);
        cloudSpawnTimer += Random.Range(30, 70);
    }

    private void spawnGround()
    {
        GameObjectCreator.createSprite(new Vector2(19f, -2.9f), groundSprites[Random.Range(0, 4)], true);
    }
    private void loadSprites(string spriteName, int amountOfSprites, List<Sprite> listOfSprites)
    {
        for (int i = 1; i <= amountOfSprites; i++)
        {
            listOfSprites.Add(Resources.Load<Sprite>(spriteName + i));
        }
    }

    public void start()
    {
        isPlaying = true;
        spawnObstacleTimer = timer + 200;
    }

    public void restart()
    {
        score = 0;
        updateScore(false);
        timer = 0;
        spawnObstacleTimer = 0;
        cloudSpawnTimer = 0;
        spawnGround();
        start();
    }

    public void stop()
    {
        isPlaying = false;
    }

    public void lose()
    {
        if (!isPlaying)
        {
            return;
        }
        stop();
        gameOverBoard.transform.position = new Vector2(0.75f, 1.5f);
        highScore = Mathf.Max(highScore, score);
        GameObject.Find(CommandWords.SCOREOBJECT).GetComponent<TextMesh>().text = "Score: " + score + "\nHighscore: " + highScore;

        for(int i = 10; i >= 1; i--)
        {
            
            if (!PlayerPrefs.HasKey(CommandWords.HIGHSCORE + i))
            {
                continue;
            }
            int currHighScore = PlayerPrefs.GetInt(CommandWords.HIGHSCORE + i);
            if (currHighScore < score)
            {
                if(i == 10)
                {
                    continue;
                }
                PlayerPrefs.SetInt(CommandWords.HIGHSCORE + (i+1), currHighScore);
            }
            else
            {
                if(i == 10)
                {
                    return;
                }
                PlayerPrefs.SetInt(CommandWords.HIGHSCORE + (i + 1), score);
                return;
            }
        }
        PlayerPrefs.SetInt(CommandWords.HIGHSCORE + 1, score);
    }
}
