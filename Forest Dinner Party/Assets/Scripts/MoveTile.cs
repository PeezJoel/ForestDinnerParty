using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    public Transform playSpace; //the main play space, which the tiles are in

    //bool isActive = false; //when a card is discarded, turns true. Changes game state to allow tiles to move, (and cards not?)

    List<string> spaceTagList;
    List<string> customerTagList;
    List<string> nullTagList;

    DragDrop dragDrop; //The drag drop script attached to an object

    private void Start()
    {
        spaceTagList = new List<string> { "|Space|" }; //the list of tags that will be given to a tile to drop on
        customerTagList = new List<string> { "|Customer|" };
        nullTagList = new List<string> { "|Null|" };
    }

    //Attached to discard space. When activated (By discarding), will let you move a tile
    public void Activate()
    {
        //isActive = true; //in tile moving state
        foreach(Transform child in playSpace) //for each tile (space)
        {
            EnableDrop(child); //the tile can be moved to empty spaces
        }
    }

    public void Deactivate()
    {
        //isActive = false; //out of tile moving state
        foreach (Transform child in playSpace) //for each tile (space)
        {
            DisableDrop(child); //the tile can be moved to empty spaces
        }
    }

    private void EnableDrop(Transform tileSpace)
    {
        if (tileSpace.childCount > 0)
        {
            dragDrop = tileSpace.GetChild(0).gameObject.GetComponent<DragDrop>();
            dragDrop.targetTags = spaceTagList;
        }
    }

    private void DisableDrop(Transform tileSpace)
    {
        if (tileSpace.childCount > 0)
        {
            Transform tile = tileSpace.GetChild(0);
            dragDrop = tile.gameObject.GetComponent<DragDrop>();
            if (tile.tag.Contains("|Meal|"))
            {
                dragDrop.targetTags = customerTagList;
            }
            else
            {
                dragDrop.targetTags = nullTagList;
            }
        }
    }

    /*Todo:
    Deactivate
     */
}