using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    //Attached to the hand space. Should give the player a hand of cards
    public GameObject handSpace;

    public int handSize;
    public List<GameObject> availableCards; //list of cards in the deck level
    int currCard; //index for the currently (randomly) selected card out of the available list
    
    //main method to draw cards
    public void CardDraw()
    {
        while(handSpace.transform.childCount < handSize && availableCards.Count > 0) //until hand is full or deck runs out
        {
            currCard = Random.Range(0, availableCards.Count); //find random card from deck list
            Instantiate(availableCards[currCard], handSpace.transform); //instantiate that card in the hand
            availableCards.RemoveAt(currCard); //remove that card from the list
        }
    }
}