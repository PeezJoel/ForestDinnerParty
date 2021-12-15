using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillCard : _BaseCook
{

    public new void CardDrop()
    {
        if (dragDrop.currentTarget.tag.Contains("|Discard|")) //When discarded
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

        Tile meal = PlaceTile();
        
        Transform up = gridManager.Up(parentSpace); //Find objects
        AddFood(gridManager.GetTile(up), meal);
        
        Transform down = gridManager.Down(parentSpace); //Find objects
        AddFood(gridManager.GetTile(down), meal);
        
        meal.ListIngredients();
        meal.UpdateScore();
    }
}