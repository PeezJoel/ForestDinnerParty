using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StewCard : MonoBehaviour
{
    public DragDrop dragDrop; //The drag and drop script attached to this object

    //Called every frame
    void Update()
    {
        if (dragDrop.isDropped) //When the object is dropped
        {
            if (dragDrop.currentTarget.tag.Contains("Discard")) //When discarded
            {
                dragDrop.currentTarget.GetComponent<MoveTile>().Activate(); //Use the discard effect
            }
            else
            {
                Effect(); //Do the main thing
            }
            Destroy(gameObject); //remove this card, now that it's been used
        }
    }

    //The main effect that this object has when dropped
    void Effect()
    {
        Transform parentSpace = dragDrop.currentTarget.transform.parent;
        GridManager gridManager = dragDrop.currentTarget.transform.parent.parent.GetComponent<GridManager>();

        GameObject downLeft = gridManager.Down(gridManager.Left(parentSpace).transform.parent); //Find objects
        GameObject upRight = gridManager.Up(gridManager.Right(parentSpace).transform.parent);

        if(downLeft.tag.Contains("|Food|"))
        {
            downLeft.transform.parent = dragDrop.currentTarget.transform;
            downLeft.transform.
        }
        if (upRight.tag.Contains("|Food|"))
        {

            upRight.transform.parent = dragDrop.currentTarget.transform;
        }
    }
}