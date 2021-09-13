using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StewCard : MonoBehaviour
{
    public DragDrop dragDrop; //The drag and drop script attached to this object
    public GameObject stewTile;

    //Called every frame
    void Update()
    {
        if (dragDrop.isDropped) //When the object is dropped
        {
            if (dragDrop.currentTarget.tag.Contains("|Discard|")) //When discarded
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

        GameObject stew = Instantiate(stewTile, parentSpace);
        Destroy(dragDrop.currentTarget);

        GameObject left = gridManager.Left(parentSpace); //Find objects
        if (left){
            GameObject downLeft = gridManager.Down(left.transform.parent);
            if (downLeft)
            {
                if (downLeft.tag.Contains("|Food|"))
                {
                    downLeft.transform.SetParent(stew.transform);
                    downLeft.transform.position = new Vector2(0, 0);
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
                    upRight.transform.SetParent(stew.transform);
                    upRight.transform.position = new Vector2(0, 0);
                }
            }
        }
    }
}