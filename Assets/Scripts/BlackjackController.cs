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
    private TextMeshProUGUI dealerScore;
    private TextMeshProUGUI playerScore;

    string[][] playingCards = new string[][]
    {
    new string[] { "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10", "HJ", "HQ", "HK", "HA" },
    new string[] { "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9", "R10", "RJ", "RQ", "RK", "RA" },
    new string[] { "S2", "S3", "S4", "S5", "S6", "S7", "S8", "S9", "S10", "SJ", "SQ", "SK", "SA" },
    new string[] { "K2", "K3", "K4", "K5", "K6", "K7", "K8", "K9", "K10", "KJ", "KQ", "KK", "KA" }
    };
    private string[] dealerCards;
    private string[] playerCards;


    private GameState currentState;

    public GameObject[] buttons;
    public GameObject startButton;

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
        currentState = GameState.Wait;
        dealerCard1 = GameObject.Find("WTD1C");
        dealerCard2 = GameObject.Find("WTD2C");
        playerCard1 = GameObject.Find("WTP1C");
        playerCard2 = GameObject.Find("WTP2C");
        buttons = GameObject.FindGameObjectsWithTag("bjAction");
        startButton = GameObject.FindGameObjectsWithTag("bjStart");

    }


    // Update is called once per frame
    void Update()
    {

        runStateMachine();

    }

    string dealCard(GameObject card, string cardName)
    {
        card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/" + cardName);
        return cardName;
    }

    string getRandomCard()
    {
        int suit = Random.Range(0, 4);
        int rank = Random.Range(0, 13);
        string card = playingCards[suit][rank];
        return card;
    }

    string dealRandomCard()
    {

        string card = getRandomCard();
        while (dealerCards.Contains(card) || playerCards.Contains(card) || cardsInPlay.Count < 51)
        {
            card = dealRandomCard();
        }
        cardsInPlay.Add(card);
        return card;
    }



    int getCardValue(string card)
    {
        string rank = card.Substring(1);
        if (rank == "A")
        {
            return 11;
        }
        else if (rank == "K" || rank == "Q" || rank == "J")
        {
            return 10;
        }
        else
        {
            return int.Parse(rank);
        }
    }


    void runStateMachine()
    {
        switch (currentState)
        {
            case GameState.Start:

                dealerCards[0] = dealCard(dealerCard1, dealRandomCard());
                playerCards[0] = dealCard(playerCard1, dealRandomCard());
                null = dealCard(dealerCard2, "B1");
                dealerCards[1] = dealRandomCard();
                playerCards[1] =dealCard(playerCard2, dealRandomCard());
                currentState = GameState.PlayerTurn;
                break;

            case GameState.PlayerTurn:
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(true);
                }
                // currentState = GameState.DealerTurn;
                break;

            case GameState.DealerTurn:
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(false);
                }

                dealCard(dealerCard2, dealerCards[2]);

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



    public void Hit()
    {
        if (currentState == GameState.PlayerTurn)
        {
            dealCard(playerCard1, dealRandomCard());
            if (getCardValue(playerCard1) > 21)
            {
                currentState = GameState.End;
            }
        }

    }

    public void Stand()
    {
        if (currentState == GameState.PlayerTurn)
        {
            currentState = GameState.DealerTurn;
        }
    }

    public void start()
    {
        if (currentState == GameState.Wait)
        {
            currentState = GameState.Start;
        }
    }


    public void spawnCard()
    {
        GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/Card"));
        card.transform.position = new Vector3(0, 0, 0);
    }

}
