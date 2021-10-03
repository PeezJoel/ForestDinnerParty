using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public DragDrop dragDrop; //the dragdrop script attached to this game object
    public int points; //how many points this tile is worth
    public List<string> ingredients; //will probably replace score in future

    GameObject gameManager; //the game manager - keeps track of everything

    public void Start()
    {
        gameManager = GameObject.Find("GameManager"); //find the game manager
    }

    public void DropTile()
    {
        gameObject.transform.parent.tag = "|Space|"; // the space that the tile was in is now free

        if (dragDrop.currentTarget.tag == "|Customer|") //delivered to customer
        {
            gameManager.GetComponent<GameManager>().AddScore(points); //get points for the tile's worth
            Remove(); //delete this tile from the scene
        }
        else //moved to a different tile space
        {
            gameObject.transform.SetParent(dragDrop.currentTarget.transform); //change parent to destination tile space
            gameObject.transform.parent.tag = "|Full|"; //the space that the tile is now in is full (other tiles can't be put here)
            gameManager.GetComponent<MoveTile>().Deactivate(); //deactivate the tile mover, now that one has been moved
        }
    }

    public void Remove() //Delete the tile
    {
        transform.parent.tag = "|Space|"; //sets the parent to be empty
        Destroy(gameObject); //remove from scene
    }
}
