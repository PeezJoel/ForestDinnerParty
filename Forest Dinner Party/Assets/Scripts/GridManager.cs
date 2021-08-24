using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    //Attaches to play space, manages the grid of tile spaces

    GridLayoutGroup gridLayout; //the grid layout group component on this object
    int columnSize; //the number of columns in this grid

    // Start is called before the first frame update
    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>(); //finds the component
        columnSize = gridLayout.constraintCount; //finds the grid size (no. of columns)


        GridLayoutGroup childGrid;
        foreach (Transform child in transform) //Makes all tile spaces (children of play space) have tiles the same size as they are
        {
            childGrid = transform.gameObject.GetComponent<GridLayoutGroup>(); //get the grid component of the child 
            childGrid.cellSize = gridLayout.cellSize; //Make same size as master grid
        }
    }



    //Finds the tile space to the left of the given one
    public GameObject Left(Transform currentSpace)
    {
        int currentIndex = currentSpace.GetSiblingIndex(); //Gets the hierarchy number of the space that the tile's in

        if (currentIndex % columnSize > 0) //If not the first in a row
        {
            Transform tileSpace = transform.GetChild(currentIndex - 1); //Finds the space to the left of the indexed one

            return GetTile(tileSpace);

        }
        else
        {
            return null; //There's no space to the left
        }
    }

    //Finds the tile space to the right of the given one
    public GameObject Right(Transform currentSpace)
    {
        int currentIndex = currentSpace.GetSiblingIndex(); //Gets the hierarchy number of the space that the tile's in

        if (currentIndex % columnSize < columnSize - 1) //If not the last in a row
        {
            Transform tileSpace = transform.GetChild(currentIndex + 1); //Finds the space to the right of the indexed one

            return GetTile(tileSpace);

        }
        else
        {
            return null; //There's no space to the right
        }
    }

    //Finds the tile space above the given one
    public GameObject Up(Transform currentSpace)
    {
        int currentIndex = currentSpace.GetSiblingIndex(); //Gets the hierarchy number of the space that the tile's in

        if (currentIndex >= columnSize) //If not in the first row
        {
            Transform tileSpace = transform.GetChild(currentIndex - columnSize); //Finds the space above the indexed one

            return GetTile(tileSpace);

        }
        else
        {
            return null; //There's no space above
        }
    }

    //Finds the tile space under the given one
    public GameObject Down(Transform currentSpace)
    {
        int currentIndex = currentSpace.GetSiblingIndex(); //Gets the hierarchy number of the space that the tile's in

        if (currentIndex < transform.childCount - columnSize) //If not in the last row
        {
            Transform tileSpace = transform.GetChild(currentIndex + columnSize); //Finds the space below the indexed one

            return GetTile(tileSpace);
        }
        else
        {
            return null; //There's no space above
        }
    }

    //Gets the tile in this space if there is one
    private GameObject GetTile(Transform tileSpace)
    {
        if (tileSpace.childCount > 0) //if there is a tile in that space
        {
            return (tileSpace.GetChild(0).gameObject); //returns the tile in that space
        }
        else
        {
            return null; //there's no tile in that space
        }
    }
}
