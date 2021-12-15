using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarnishCard : MonoBehaviour
{
    public DragDrop dragDrop; //The drag and drop script attached to this object
    public string ingredientName; //the name of the ingredient that the garnish is
    public int points; //The number of points that the garnish adds

    //When dropped
    public void CardDrop()
    {

        if (dragDrop.currentTarget.tag.Contains("|Discard|"))//When discarded
        {
            GameObject.Find("GameManager").GetComponent<MoveTile>().Activate(); //Use the discard effect
        }
        else
        {
            Effect(); //Do the main thing
        }
        Destroy(gameObject); //remove this card, now that it's been used
    }

    //The main effect that this object has when dropped
    void Effect()
    {
        Tile tile = dragDrop.currentTarget.GetComponent<Tile>();
        tile.ingredients.Add(ingredientName);
        tile.points += points;
        tile.ListIngredients();
        tile.UpdateScore();
    }
}
