using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCard : MonoBehaviour
{
    public DragDrop dragDrop; //The drag and drop script attached to this object

    //Called every frame
    void Update()
    {
        if (dragDrop.isDropped) //When the object is dropped
        {
            if (dragDrop.currentTarget.tag.Contains("Discard"))//When discarded
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
        Destroy(dragDrop.currentTarget);
    }
}