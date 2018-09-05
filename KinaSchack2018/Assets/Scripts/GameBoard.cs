using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour {

    [SerializeField]
    GameObject NodePrefab;

    int width = 10;
    int heigt = 12;

    float offsetRowX = 0.88f;
    float offsetRowY = 0.76f; 
	// Use this for initialization
	void Start ()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigt; y++)
            {
                float xPos = x * offsetRowX;
                if (y % 2 == 1)
                {
                    xPos += offsetRowX / 2;
                }
                Instantiate(NodePrefab, new Vector3(xPos, 0, y * offsetRowY), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
