using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StewCard : _BaseCook
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


        Transform left = gridManager.Left(parentSpace); //Find objects
        if (left){
            Transform downLeft = gridManager.Down(left);
            AddFood(gridManager.GetTile(downLeft), meal);
        }

        Transform right = gridManager.Right(parentSpace);
        if (right) {
            Transform upRight = gridManager.Up(right);
            AddFood(gridManager.GetTile(upRight), meal);
        }

        meal.ListIngredients();
        meal.UpdateScore();
    }
}