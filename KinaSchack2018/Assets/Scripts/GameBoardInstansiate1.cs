using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardInstansiate1 : MonoBehaviour {

    [SerializeField]
    GameObject NodePrefab;

    int radius = 4;
	// Use this for initialization
	void Start ()
    {
        List<Vector3> tileCoordinates = new List<Vector3>();


        //Code to fill the list with coordinates
        //Adds the middle tile
        tileCoordinates.Add(new Vector3(0, 0, 0));
        //Generates the central row
        for (int i = 0; i < radius; i++)
        {
            tileCoordinates.Add(new Vector3(0, 0, i + 1));
            tileCoordinates.Add(new Vector3(0, 0, -i - 1));
            
        }

        //Generates remaining rows

        int rowsRemaining = radius * 2; //Tracks amount of rows left to generate
        float horizontalDisplacement = 0; //How far the generated tile should be moved horizontally
        float verticalDisplacement = 0; //How far the generated tile should be moved vertically
        int currentRowLength = radius * 2; //Length of the current row being generated (amount of tiles)

        //This loops runs once for each row remaining
        for (int rowID = 0; rowID < rowsRemaining; rowID++)
        {

            //If past half the rows (thus switching to lower rows), reset counters
            if (rowID == radius)
            {
                horizontalDisplacement = 0;
                verticalDisplacement = 0;
                currentRowLength = radius * 2;
            }

            //For each row, update the counters
            horizontalDisplacement = horizontalDisplacement + 0.5f;
            currentRowLength = currentRowLength - 1;
            //If it's an upper row
            if (rowID < radius)
            {
                verticalDisplacement = verticalDisplacement + 0.866f;
            }
            //If it's a lower row
            else
            {
                verticalDisplacement = verticalDisplacement - 0.866f;
            }
            float currentX = verticalDisplacement;

            //Generate the tile coordinates for this row
            for (int tileID = 0; tileID <= currentRowLength; tileID++)
            {
                tileCoordinates.Add(new Vector3(verticalDisplacement, 0, radius - tileID - horizontalDisplacement));
            }


            for (int x = 0; x < 5; x++)
            {
                float currentY = radius - x + horizontalDisplacement;

                if (currentY >= 3f && currentX > 2f || currentY >= 3f && currentX < -2f || currentY >= 4f && currentX >= 0.8f || currentY >= 4f && currentX < -0.8f)
                {
                    tileCoordinates.Add(new Vector3(currentX, 0, currentY));
                }
                else
                { // If X is negative it should be posetive and the other way around.
                    if (currentX > 0)
                    { tileCoordinates.Add(new Vector3(currentX - 4.3f, 0, currentY - 6.5f)); } // TODO: moduleära variabler för 4.3f och 6.5f...
                        else
                    { tileCoordinates.Add(new Vector3(currentX + 4.3f, 0, currentY - 6.5f)); }

                    
                }
            }

        }

        //Use the generated list of coordinates to instantiate the tile prefabs
        for (int i = 0; i < tileCoordinates.Count; i++)
        {
            //Create new tile and name it
            GameObject newTile = (GameObject)Instantiate(NodePrefab, tileCoordinates[i], Quaternion.Euler(0f, 30f, 0f));
            newTile.gameObject.name = "tile_" + i.ToString();

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
