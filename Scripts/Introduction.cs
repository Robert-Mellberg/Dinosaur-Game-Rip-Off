using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour {

    // Use this for initialization

    Player playerScript;
    Main mainScript;
    GameObject parent;
    Sprite checkBox;

    void Start () {
        checkBox = Resources.Load<Sprite>(CommandWords.CHECKBOX);
        mainScript = gameObject.AddComponent<Main>();
        playerScript = GameObject.Find(CommandWords.PLAYEROBJECT).GetComponent<Player>();
        if (PlayerPrefs.GetInt(CommandWords.HIGHSCORE + "1") != 0)
        {
            mainScript.start();
            Destroy(this);
        }
        else
        {
            parent = new GameObject();
            parent.transform.position = new Vector2(-3.9f, 1.5f);
            GameObjectCreator.createText(new Vector2(-3.7f, 1.4f), "Press the up arrow or say \"jump\" into the mic").transform.parent = parent.transform;
            GameObjectCreator.createText(new Vector2(-3.7f, 0.4f), "Press the down arrow or say \"duck\" into the mic").transform.parent = parent.transform;
        }
	}

    bool hasJumped = false;
    bool hasDucked = false;
    int timer = 9999999;
	// Update is called once per frame
	void Update () {
        timer++;
        if(timer == 150)
        {
            mainScript.start();
            Destroy(parent);
            Destroy(this);
        }
		if(hasJumped && hasDucked && timer > 150)
        {
            timer = 0;
            return;
        }
        if(playerScript.isJumping == true && !hasJumped)
        {
            hasJumped = true;
            GameObjectCreator.createSprite(new Vector2(6.7f, 1.1f), checkBox, false).transform.parent = parent.transform;
        }
        if (playerScript.isDucking == true && !hasDucked)
        {
            hasDucked = true;
            GameObjectCreator.createSprite(new Vector2(7.1f, 0.1f), checkBox, false).transform.parent = parent.transform;
        }

    }
}
