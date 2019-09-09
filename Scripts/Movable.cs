using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

    // Use this for initialization
    float xPosition;
    float yPosition;
	void Start () {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        xPosition -= 0.10f;
        if (xPosition < -16f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector2(xPosition, yPosition);
        }

	}
}
