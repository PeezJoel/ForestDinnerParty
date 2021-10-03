using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StewCard : MonoBehaviour
{
    public DragDrop dragDrop; //The drag and drop script attached to this object
    public GameObject stewTile;
    Tile tile;

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
        Transform parentSpace = dragDrop.currentTarget.transform.parent;
        GridManager gridManager = dragDrop.currentTarget.transform.parent.parent.GetComponent<GridManager>();

        GameObject stewObj = Instantiate(stewTile, parentSpace);
        dragDrop.currentTarget.GetComponent<Tile>().Remove();
        Tile stew = stewObj.GetComponent<Tile>();


        GameObject left = gridManager.Left(parentSpace); //Find objects
        if (left){
            GameObject downLeft = gridManager.Down(left.transform.parent);
            if (downLeft)
            {
                if (downLeft.tag.Contains("|Food|"))
                {
                    tile = downLeft.GetComponent<Tile>();
                    stew.points += tile.points;
                    stew.ingredients.AddRange(tile.ingredients);
                    tile.Remove();
                }
            }
        }

        GameObject right = gridManager.Right(parentSpace);
        if (right) {
            GameObject upRight = gridManager.Up(right.transform.parent);
            if (upRight)
            {
                if (upRight.tag.Contains("|Food|"))
                {
                    tile = upRight.GetComponent<Tile>();
                    stew.points += tile.points;
                    stew.ingredients.AddRange(tile.ingredients);
                    tile.Remove();
                }
            }
        }
    }
}