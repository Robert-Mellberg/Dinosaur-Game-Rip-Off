using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for(int i = 1; i <= 10; i++)
        {
            if(!PlayerPrefs.HasKey(CommandWords.HIGHSCORE + i))
            {
                return;
            }
            int score = PlayerPrefs.GetInt(CommandWords.HIGHSCORE + i);
            string scoreString = "";
            if(score < 10)
            {
                scoreString = "00" + score;
            }
            else if(score < 100)
            {
                scoreString = "0" + score;
            }
            else
            {
                scoreString = score.ToString();
            }

            if(i <= 5)
            {
                GameObject.Find(CommandWords.SCOREOBJECT).GetComponent<TextMesh>().text += i + ": " + scoreString + "\n";
            }
            else
            {
                GameObject.Find(CommandWords.SCOREOBJECT + "1").GetComponent<TextMesh>().text += i + ": " + scoreString + "\n";
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
