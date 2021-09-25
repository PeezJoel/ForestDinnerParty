using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public DragDrop dragDrop;
    public int score;
    public List<string> ingredients; //will probably replace score in future

    MoveTile moveTile;

    public void Start()
    {
        
        moveTile = GameObject.Find("GameManager").GetComponent<MoveTile>();
    }

    public void DropTile()
    {
        gameObject.transform.parent.tag = "|Space|";
        if (dragDrop.currentTarget.tag == "|Customer|")
        {
            Debug.Log(ingredients);
        }
        else
        {
            gameObject.transform.SetParent(dragDrop.currentTarget.transform);
            gameObject.transform.parent.tag = "|Full|";
            moveTile.Deactivate();
        }
    }

    public void Remove()
    {
        transform.parent.tag = "|Space|";
        Destroy(gameObject);
    }
}
