using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tiphiderscript : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject text;
    private TextMeshProUGUI textmeshPro;
    bool active = true;

    string inactivetext = "Press H to show the Tips";
    string activetext = "Blackjack Rules: \n Try to get as close to 21.\n Do not go over 21.\n Ace is 1 or 11.\n Face cards are 10.\n Other cards are pip value.\n Payout is 3 to 2.\n Bet 2 get 3 back on win.\n \n Press H to hide tips.";


    void Start()
    {
        textmeshPro = text.GetComponent<TextMeshProUGUI>();
        textmeshPro.text = activetext;
        text.SetActive(active);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {

            active = !active;
            // text.SetActive(active);
            if (active)
                textmeshPro.text = activetext;
            else
                textmeshPro.text = inactivetext;
        }
    }

}
