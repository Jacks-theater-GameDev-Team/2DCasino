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


    void Start()
    {
        dealerCard1 = GameObject.Find("WTD1C");
        dealerCard2 = GameObject.Find("WTD2C");
        playerCard1 = GameObject.Find("WTP1C");
        playerCard2 = GameObject.Find("WTP2C");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
