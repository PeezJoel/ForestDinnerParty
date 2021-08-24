using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour
{
    //Attached to the main play space. This should populate each tile space with a tile until they run out

    public List<GameObject> availableTiles; //list of tiles used in this level
    int currTile; //index for the currently (randomly) selected tile out of the available list
    
    //main method to generate tiles
    public void TileGenerator()
    {
        foreach (Transform child in transform) //for each tile space (children of play space)
        {
            if (child.childCount == 0) //if there isn't already a tile
            {
                if (availableTiles.Count > 0) //if there are still available tiles
                {
                    currTile = Random.Range(0, availableTiles.Count); //find random tile from list
                    Instantiate(availableTiles[currTile], child); //instantiate that tile under the tile space
                    availableTiles.RemoveAt(currTile); //remove that tile from the list
                }
            }
        }
    }
}
