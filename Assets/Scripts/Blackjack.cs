using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : MonoBehaviour
{
    [SerializeField] private Sprite[] cardDeck;

    // Start is called before the first frame update
    void Start()
    {
        reshuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void reshuffle()
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < cardDeck.Length; t++)
        {
            Sprite tmp = cardDeck[t];
            int r = Random.Range(t, cardDeck.Length);
            cardDeck[t] = cardDeck[r];
            cardDeck[r] = tmp;
        }
    }
}
