using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playSpace; //The play space, which has all the current tiles/spaces
    public GameObject handSpace; //The hand space, which has all the player's cards
    GenerateTiles generateTiles;
    DrawCards drawCards;
    GridManager gridManager;
    MoveTile moveTile;

    int turn = 0; //keeps track of current turn
    public Text turnDisplay; //displays the turn number in UI
    public GameObject turnButton; //the button that lets the player move to next turn

    int score = 0; //keeps track of player's score
    public Text scoreDisplay; //displays the current score in UI

    // Start is called before the first frame update
    void Start()
    {
        gridManager = playSpace.GetComponent<GridManager>(); //find grid manager (on playspace game object)
        gridManager.SetGridSize(); //scales the grid
        gridManager.MakeTileSpaces(); //instantiates the tile spaces for the grid
        
        generateTiles = GetComponent<GenerateTiles>(); //find the tile generator

        drawCards = GetComponent<DrawCards>(); //find the card generator

        moveTile = GetComponent<MoveTile>(); //find the tile mover

        NextTurn(); //go to turn 1
    }

    // Update is called once per frame
    void Update()
    {
        if(handSpace.transform.childCount == 0) //if player has no cards
        {
            turnButton.SetActive(true); //Enable a button to move to next turn
        }
    }

    //At end of turn, when player has no more actions
    public void NextTurn()
    {
        turn += 1; //increment the turn counter

        turnButton.SetActive(false); //Disable turn button

        moveTile.Deactivate(); //Disable tile movement

        drawCards.CardDraw(); //Draw new hand

        generateTiles.TileGenerator(); //Fill the board
        
        turnDisplay.text = turn.ToString(); //Update the turn counter display
    }

    //Add a new score to the total
    public void AddScore(int points)
    {
        score += points; //add points to the total

        scoreDisplay.text = score.ToString(); //update display with new total score
    }
}