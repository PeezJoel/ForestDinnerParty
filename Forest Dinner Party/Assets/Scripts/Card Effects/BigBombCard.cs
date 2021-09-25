using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBombCard : MonoBehaviour
{
    //Currently broken due to GetComponent sometimes referencing a null object (lines 29-32)

    public DragDrop dragDrop; //The drag and drop script attached to this object

    public void CardDrop()
    {

        if (dragDrop.currentTarget.tag.Contains("Discard"))//When discarded
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
    void Effect() //blows up the target and all adjacent tiles
    {
        GridManager gridManager = dragDrop.currentTarget.transform.parent.parent.gameObject.GetComponent<GridManager>();
        gridManager.Up(dragDrop.currentTarget.transform.parent).GetComponent<Tile>().Remove();
        gridManager.Left(dragDrop.currentTarget.transform.parent).GetComponent<Tile>().Remove();
        gridManager.Right(dragDrop.currentTarget.transform.parent).GetComponent<Tile>().Remove();
        gridManager.Down(dragDrop.currentTarget.transform.parent).GetComponent<Tile>().Remove();
        dragDrop.currentTarget.GetComponent<Tile>().Remove();
    }
}