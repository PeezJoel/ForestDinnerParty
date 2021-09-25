using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    //Attaches to play space, manages the grid of tile spaces.
    //Is used by other scripts to find each other

    public GridLayoutGroup gridLayout; //the grid layout group component on this object

    public int columnCount; //the number of columns in this grid
    public int rowCount; //The number of rows in this grid

    public GameObject tileSpace; //The tile space prefab

    float cellSpaceRatio = 0.233f; //The ratio of how big the spaces between cells are, compared to the cells themselves

    float width; //Width and height of the playspace transform in UI
    float height;

    // Start is called before the first frame update
    void Start()
    {
    }

     //Sets the size and spacing of the grid, based on the column/row count
    public void SetGridSize()
    {
        RectTransform rectTrans = GetComponent<RectTransform>(); //The size of the playSpace
        width = rectTrans.rect.width; //get play space width/height
        height = rectTrans.rect.height;

        gridLayout.constraintCount = columnCount; //sets the grid size (no. of columns)


        float cellWidth = width / (columnCount + (columnCount + 1) * cellSpaceRatio); //use maths to find the size that cells should be
        float cellHeight = height / (rowCount + (rowCount + 1) * cellSpaceRatio);
        gridLayout.cellSize = new Vector2(cellWidth, cellHeight); //put that cell size into the grid layout


        float horizontalSpace = (width - (cellWidth * columnCount)) / (columnCount + 1); //find appropriate size for spaces between and around cells
        gridLayout.padding.left = (int)horizontalSpace; //set the initial padding

        float verticalSpace = (height - (cellHeight * rowCount)) / (rowCount + 1);
        gridLayout.padding.top = (int)verticalSpace;

        gridLayout.spacing = new Vector2(horizontalSpace, verticalSpace); //set the gaps between cells
    }

    public void MakeTileSpaces()
    {
        int tileCount = columnCount * rowCount; //Calculate how big the grid is
        for(int i = 0; i < tileCount; i++) //generate tile spaces until the board is full
        {
            Instantiate(tileSpace, transform); //uses the prefab
        }

        GridLayoutGroup childGrid;
        foreach (Transform child in transform) //Makes all tile spaces (children of play space) have tiles the same size as they are
        {
            childGrid = child.gameObject.GetComponent<GridLayoutGroup>(); //get the grid component of the child 
            childGrid.cellSize = gridLayout.cellSize; //Make same size as master grid
        }
    }


    //Finds the tile space to the left of the given one
    public GameObject Left(Transform currentSpace)
    {
        int currentIndex = currentSpace.GetSiblingIndex(); //Gets the hierarchy number of the space that the tile's in

        if (currentIndex % columnCount > 0) //If not the first in a row
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

        if (currentIndex % columnCount < columnCount - 1) //If not the last in a row
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

        if (currentIndex >= columnCount) //If not in the first row
        {
            Transform tileSpace = transform.GetChild(currentIndex - columnCount); //Finds the space above the indexed one

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

        if (currentIndex < transform.childCount - columnCount) //If not in the last row
        {
            Transform tileSpace = transform.GetChild(currentIndex + columnCount); //Finds the space below the indexed one

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
