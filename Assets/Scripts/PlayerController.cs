using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject Floor;
    public GameObject Ceiling;

    float playerSpeedX = 0.5f;
    float playerSpeedY = 0.4f;

	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        checkBoundaries(ref inputX, ref inputY);

        transform.Translate(new Vector3(inputX * playerSpeedX, inputY * playerSpeedY, 0f));
    }

    void checkBoundaries(ref float inputX, ref float inputY)
    {
        if ((transform.position.x - transform.localScale.x / 2 <=
            LeftWall.transform.position.x + LeftWall.transform.localScale.x / 2 && inputX < 0) ||
            (transform.position.x + transform.localScale.x / 2 >=
            RightWall.transform.position.x - RightWall.transform.localScale.x / 2 && inputX > 0))
        {
            inputX = 0;
        }

        if ((transform.position.y - transform.localScale.y / 2 <=
            Floor.transform.position.y + Floor.transform.localScale.y && inputY < 0) ||
            (transform.position.y + transform.localScale.y / 2 >=
            Ceiling.transform.position.y - Ceiling.transform.localScale.y / 2 && inputY > 0))
        {
            inputY = 0;
        }
        
    }
    
}
