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

    // private string[4][13] playingCards;

    private GameState currentState;



    private enum GameState
    {
        Start,
        PlayerTurn,
        DealerTurn,
        End
}

    private string[][] Cards;


void Start()
{





    currentState = GameState.Start;
    dealerCard1 = GameObject.Find("WTD1C");
    dealerCard2 = GameObject.Find("WTD2C");
    playerCard1 = GameObject.Find("WTP1C");
    playerCard2 = GameObject.Find("WTP2C");
}

// Update is called once per frame
void Update()
{

    runStateMachine();

}

// Sprite dealCard(string cardName)
// {
    // return card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/" + cardName);
// }

void runStateMachine()
{
    switch (currentState)
    {
        case GameState.Start:





            // playerCard1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cards/2C");
            //     playerCard2.GetComponent<SpriteRenderer>().sprite = dealCard();
            // currentState = GameState.PlayerTurn;
            break;

        case GameState.PlayerTurn:

            currentState = GameState.DealerTurn;
            break;

        case GameState.DealerTurn:

            currentState = GameState.End;
            break;

        case GameState.End:

            currentState = GameState.Start;
            break;
    }
}
}
