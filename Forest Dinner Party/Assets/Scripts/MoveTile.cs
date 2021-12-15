using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    public Transform playSpace; //the main play space, which the tiles are in

    List<string> spaceTagList;
    List<string> customerTagList;
    List<string> nullTagList;

    DragDrop dragDrop; //The drag drop script attached to an object

    private void Start()
    {
        spaceTagList = new List<string> { "|Space|"/*, "|Discard|"*/ }; //the list of tags that will be given to a tile to drop on; Discard is currently not in use for tiles, see also Tile.cs line 31
        customerTagList = new List<string> { "|Customer|" }; //the list of tags for a ready meal
        nullTagList = new List<string> { "|Null|" }; //the list of tags for a tile that can't move
    }

    //When activated (By discarding), will let you move a tile
    public void Activate()
    {
        //isActive = true; //in tile moving state
        foreach(Transform child in playSpace) //for each tile (space)
        {
            EnableDrop(child); //the tile can be moved to empty spaces
        }
    }

    //Stops tiles from moving
    public void Deactivate()
    {
        //isActive = false; //out of tile moving state
        foreach (Transform child in playSpace) //for each tile (space)
        {
            DisableDrop(child); //the tile can be moved to empty spaces
        }
    }

    //changes the taglist of where a tile can be dropped, letting it move to empty spaces
    private void EnableDrop(Transform tileSpace)
    {
        if (tileSpace.childCount > 0) //if there is a tile in the space
        {
            dragDrop = tileSpace.GetChild(0).gameObject.GetComponent<DragDrop>(); //get the tile's dragdrop
            dragDrop.targetTags = spaceTagList; //change the tag list, allowing for movement to empty tile spaces
        }
    }

    //changes the taglist of where a tile can be dropped, disabling movement to other spaces
    private void DisableDrop(Transform tileSpace)
    {
        if (tileSpace.childCount > 0) //if there is a tile in the space
        {
            Transform tile = tileSpace.GetChild(0); //get the tile
            dragDrop = tile.gameObject.GetComponent<DragDrop>(); //get the tile's dragdrop
            if (tile.tag.Contains("|Meal|")) //if the tile is a meal, it can still be delivered to customers
            {
                dragDrop.targetTags = customerTagList;
            }
            else //can't drop anywhere
            {
                dragDrop.targetTags = nullTagList;
            }
        }
    }
}

//todo: let meals have customer and space tags at same time