using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BricksController : MonoBehaviour {

    public GameObject brickPrefab;
    public Text bricksLeftText;

    private float leftUpX = -9.5f;
    private float leftUpY = -4.5f;

    private int bricksH = 13;
    private int bricksV = 7;
    private float spacing = 1.5f;

    //we fit 13 bricks horizontally and 7 vertically
    private int brickCount = 0;
    GameObject[,] brickArray = new GameObject[13, 7];

	void Start () {

        brickCount = bricksH * bricksV;
        bricksLeftText.text = "Bricks left: " + brickCount;
        for(int i=0; i<bricksH; i++)
            for (int j=0; j<bricksV; j++)
            {
                brickArray[i,j] = Instantiate(brickPrefab,
                    new Vector3(leftUpX + (float)i * spacing + 0.5f, leftUpY + (float)j * spacing, 14f),
                    Quaternion.identity) as GameObject;
            }
	}
	
    public void BrickDestroyed()
    {
        brickCount--;
        bricksLeftText.text = "Bricks left: " + brickCount;
    }
}
