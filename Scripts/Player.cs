using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Animator animator;

    const float GRAVITY = -0.03f;
    const float INITIALYPOSITION = -2;
    const float INITIALXPOSITION = -7;

    const float XSIZE = 2;
    const float YSIZE = 2;

    GameObject g;


	// Use this for initialization
	void Start () {
		g = GameObject.Find(CommandWords.PLAYEROBJECT);
        g.transform.position = new Vector2(INITIALXPOSITION, INITIALYPOSITION);
        g.transform.localScale = new Vector2(XSIZE, YSIZE);

        animator = g.GetComponent<Animator>();
    }

    // Update is called once per frame
    const int DUCKDURATION = 100;
    const int JUMPDURATION = 100;
    int duckTime = 0;
    int jumpTime = 0;
	void Update () {
        duckTime++;
        jumpTime++;

        if(jumpTime == JUMPDURATION)
        {
            isJumping = false;
        }
        if(duckTime == DUCKDURATION)
        {
            isDucking = false;
        }
		
	}

    public bool isJumping = false;
    public void jump()
    {
        if (!isDucking && !isJumping)
        {
            animator.SetTrigger("JUMP");
            isJumping = true;
            jumpTime = 0;
        }
    }

    public bool isDucking = false;
    public void duck()
    {
        if (!isJumping && !isDucking)
        {
            animator.SetTrigger("DUCK");
            duckTime = 0;
            isDucking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Main Camera").GetComponent<Main>().lose();
    }
}
