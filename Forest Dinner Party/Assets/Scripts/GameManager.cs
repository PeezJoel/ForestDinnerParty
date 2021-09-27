using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playSpace;
    public GameObject handSpace;
    GenerateTiles generateTiles;
    DrawCards drawCards;
    GridManager gridManager;

    int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = playSpace.GetComponent<GridManager>();
        gridManager.SetGridSize();
        gridManager.MakeTileSpaces();
        
        generateTiles = GetComponent<GenerateTiles>();
        generateTiles.TileGenerator();

        drawCards = GetComponent<DrawCards>();
    }

    // Update is called once per frame
    void Update()
    {
        if(handSpace.transform.childCount == 0) //if player has no cards
        {
            NextTurn(); //move to next turn
        }
    }

    //At end of turn, when player has no more actions
    void NextTurn()
    {
        drawCards.CardDraw(); //Draw new hand

        generateTiles.TileGenerator(); //Replenish the board

        turn += 1; //increment the turn counter
    }
}