using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BaseCook : MonoBehaviour
{
    public DragDrop dragDrop; //The drag and drop script attached to this object
    public GameObject mealTile;

    [HideInInspector]
    public Transform parentSpace;
    [HideInInspector]
    public GridManager gridManager;

    public void CardDrop()
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

    }

    public Tile PlaceTile()
    {

        if (dragDrop.currentTarget.tag.Contains("|Tile|"))
        {
            parentSpace = dragDrop.currentTarget.transform.parent;
            gridManager = dragDrop.currentTarget.transform.parent.parent.GetComponent<GridManager>();
            dragDrop.currentTarget.GetComponent<Tile>().Remove();
        }
        else //is an empty space
        {
            parentSpace = dragDrop.currentTarget.transform;
            gridManager = dragDrop.currentTarget.transform.parent.GetComponent<GridManager>();
            parentSpace.tag = "|Full|";
        }

        GameObject mealObj = Instantiate(mealTile, parentSpace);
        Tile meal = mealObj.GetComponent<Tile>();

        return meal;
    }

    //Add a food tile's points and such to the meal
    public void AddFood(GameObject foodTile, Tile meal)
    {
        if (foodTile) //the tile exists (not an empty space / off grid)
        {
            if (foodTile.tag.Contains("|Food|")) //It is a food, can be put in the meal
            {
                Tile tile = foodTile.GetComponent<Tile>();
                meal.points += tile.points;
                meal.ingredients.AddRange(tile.ingredients);
                tile.Remove();
            }
        }
    }
}