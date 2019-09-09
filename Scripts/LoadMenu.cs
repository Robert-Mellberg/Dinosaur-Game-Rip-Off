using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    bool isClicking = false;
    bool firstClickOnButton = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isClicking)
            {
                firstClickOnButton = GetComponent<SpriteRenderer>().bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)); ;
            }
            isClicking = true;
        }
        else if (isClicking)
        {
            if (firstClickOnButton && GetComponent<SpriteRenderer>().bounds.Contains((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                SceneManager.LoadScene(CommandWords.MENUSCENE);
            }

            isClicking = false;
        }
    }
}
