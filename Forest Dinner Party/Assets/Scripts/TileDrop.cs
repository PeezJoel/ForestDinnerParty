using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDrop : MonoBehaviour
{
    public DragDrop dragDrop;

    // Update is called once per frame
    void Update()
    {
        if (dragDrop.isDropped) //When the object is dropped
        {
            gameObject.transform.parent = dragDrop.currentTarget.transform;
        }
    }
}
