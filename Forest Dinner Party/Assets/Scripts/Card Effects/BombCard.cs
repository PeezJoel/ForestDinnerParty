using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCard : MonoBehaviour
{
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
    void Effect()
    {
        dragDrop.currentTarget.GetComponent<Tile>().Remove();
    }
}