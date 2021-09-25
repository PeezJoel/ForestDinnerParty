using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragDrop : MonoBehaviour
{
    //This class is used by an event trigger on the object

    
    [HideInInspector]
    public Vector2 startPos; //Keeps track of where the item was before drag
    bool isDragging; //Is true when item is currently being dragged


    public List<string> targetTags; //The tags that are used for objects this can be dropped on
    [HideInInspector]
    public GameObject currentTarget; //The drop zone that the item is currently over (or null)

    [SerializeField]
    private UnityEvent dropTrigger; //Invoked when the game object is dropped onto a valid drop zone.

    // Update is called once per frame
    void Update()
    {
        Drag();
    }

    //moves the attached object
    public void Drag()
    {
        if (isDragging)
        {
            //follow cursor (or finger)
            transform.position = Input.mousePosition;
        }
    }

    //start dragging (pick up)
    public void BeginDrag()
    {
        startPos = transform.position; //set position, to revert to if illegal drop
        isDragging = true;
    }

    //Finish dragging (put down)
    public void EndDrag()
    {
        isDragging = false;
        if (currentTarget != null) //Has a target
        {
            dropTrigger.Invoke(); //Do the thing, with the current drop zone target
        }
        else
        {
            transform.position = startPos; //return to original place, before drag
        }
    }

    //When enter a legal drop zone, set current target
    private void OnTriggerEnter2D(Collider2D collision)
    {

        bool hasAllTags = true; //Check that the object has all necessary tags
        for(int i = 0; i < targetTags.Count; i++)
        {
            if (!collision.gameObject.tag.Contains(targetTags[i])) //Is missing a tag
            {
                hasAllTags = false;
            }
        }

        if (hasAllTags) //Is legal
        {
            currentTarget = collision.gameObject; //sets to target, meaning it will drop onto it
        }
    }

    //Exit current drop zone, lose target
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTarget) //If leave current target zone
        {
            currentTarget = null; //No target, meaning can't drop here
        }
    }
}
