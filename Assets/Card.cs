using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Card", menuName = "Card/Card")]
public class Card : ScriptableObject
{

    public string cardID;
    public int value;
    public Sprite cardSprite;
    public Vector3 position;

    public void Initialize(string cardID, Vector3 position)
    {
        this.cardID = cardID;



        Sprite[] sprites = Resources.LoadAll<Sprite>("Assets/Sprites/Blackjack_Scene/pokerCards.png");

        foreach (Sprite sprite in sprites)
        {
            if (sprite.name == cardID)
            {
                this.cardSprite = sprite;
                break;
            }
        }
        if (this.cardSprite != null)
        {
            GameObject card = new GameObject(cardID);
            card.AddComponent<SpriteRenderer>().sprite = this.cardSprite;
            card.transform.position = position;
        }
        else
        {
            throw new NullReferenceException("The card sprite was not found.");
        }


    }

    public void Initialize(Card card)
    {
        this.cardID = card.cardID;
        this.value = card.value;
        this.cardSprite = card.cardSprite;
    }

    public void Print()
    {
        Debug.Log("cardID: " + cardID + " Value: " + value);
    }

}
