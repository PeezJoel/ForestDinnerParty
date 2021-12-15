using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public DragDrop dragDrop; //the dragdrop script attached to this game object
    public int points; //how many points this tile is worth
    public List<string> ingredients; //will probably replace score in future
    public Text ingredientDisplay; //The text list of ingredients attached to the object
    public Text scoreDisplay; //The text display of points

    GameObject gameManager; //the game manager - keeps track of everything

    public void Start()
    {
        gameManager = GameObject.Find("GameManager"); //find the game manager
        UpdateScore();

    }

    public void DropTile()
    {
        gameObject.transform.parent.tag = "|Space|"; // the space that the tile was in is now free

        if (dragDrop.currentTarget.tag == "|Customer|") //delivered to customer
        {
            gameManager.GetComponent<GameManager>().AddScore(points); //get points for the tile's worth
            Remove(); //delete this tile from the scene
        }/*else if(dragDrop.currentTarget.tag == "|Discard|") //If tile is moved to discard; Discard is currently not in use for tiles, see also MoveTile.cs line 17
        {
            Remove(); //remove tile from game
        }*/ 
        else //moved to a different tile space
        {
            gameObject.transform.SetParent(dragDrop.currentTarget.transform); //change parent to destination tile space
            gameObject.transform.parent.tag = "|Full|"; //the space that the tile is now in is full (other tiles can't be put here)
            gameManager.GetComponent<MoveTile>().Deactivate(); //deactivate the tile mover, now that one has been moved
        }
    }

    //Make the ingredient list show up in text on the tile
    public void ListIngredients()
    {
        string listedIngredients = ""; //Initialise an empty string

        for (int i = 0; i < ingredients.Count; i++) //for each ingredient
        {
            listedIngredients += ingredients[i]; //add ingredient to string
            if (i < ingredients.Count - 1) //if not last
            {
                listedIngredients += ", "; //add space
            }
        }

        ingredientDisplay.text = listedIngredients; //display
    }

    //display the score
    public void UpdateScore()
    {
        scoreDisplay.text = points.ToString(); //update display
    }

    //Delete the tile
    public void Remove() 
    {
        transform.parent.tag = "|Space|"; //sets the parent to be empty
        Destroy(gameObject); //remove from scene
    }
}