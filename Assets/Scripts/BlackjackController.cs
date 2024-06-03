using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlackjackController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dealerCard1;
    public GameObject dealerCard2;
    public GameObject playerCard1;
    public GameObject playerCard2;
    public TextMeshProUGUI dealerScore;
    public TextMeshProUGUI playerScore;

    // private string[4][13] playingCards = new string[4][13];
    private string[] cardsInPlay;

    private GameState currentState;



    private enum GameState
    {
        Start,
        PlayerTurn,
        DealerTurn,
        End,
        Wait
    }

    private string[][] Cards;


    void Start()
    {
        InitCards();
        currentState = GameState.Start;
        dealerCard1 = GameObject.Find("WTD1C");
        dealerCard2 = GameObject.Find("WTD2C");
        playerCard1 = GameObject.Find("WTP1C");
        playerCard2 = GameObject.Find("WTP2C");
    }
    void InitCards()
    {
        // playingCards[0] = { "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK", "HA"};
        // playingCards[1] = { "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9", "R10", "RJ", "RQ", "RK", "RA"};
        // playingCards[2] = { "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "SJ", "SQ", "SK", "SA"};
        // playingCards[3] = { "K2", "K3", "K4", "K5", "K6", "K7", "K8", "K9", "K10", "KJ", "KQ", "KK", "KA"};
    }

    // Update is called once per frame
    void Update()
    {

        runStateMachine();

    }

    // Sprite dealCard(GameObject card, string cardName)
    // {
    //     card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/" + cardName);
    // }

    // string getRandomCard()
    // {
    //     int suit = Random.Range(0, 4);
    //     int rank = Random.Range(0, 13);
    //     string card = playingCards[suit][rank];
    //     return card;
    // }

    // string dealRandomCard()
    // {
    //     string card = getRandomCard();
    //     while (cardsInPlay.Contains(card))
    //     {
    //         card = dealRandomCard();
    //     }
    //     cardsInPlay.Add(card);
    //     return card;
    // }
    void runStateMachine()
    {
        switch (currentState)
        {
            case GameState.Start:

                // dealCard(dealerCard1, dealRandomCard());
                // dealCard(playerCard1, dealRandomCard());
                // dealCard(playerCard2, dealRandomCard());

                if (Input.GetKeyDown(KeyCode.Space))
                {

                }

                currentState = GameState.PlayerTurn;
                break;

            case GameState.PlayerTurn:

                currentState = GameState.DealerTurn;
                break;

            case GameState.DealerTurn:

                currentState = GameState.End;
                break;

            case GameState.End:

                currentState = GameState.Wait;
                break;
            case GameState.Wait:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentState = GameState.Start;
                }
                break;
        }
    }
}
