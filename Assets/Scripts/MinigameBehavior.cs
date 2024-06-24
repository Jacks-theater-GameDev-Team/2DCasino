using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameBehavior : MonoBehaviour
{
    [SerializeField] int bettingAmount;
    [SerializeField] string bettingName;
    [SerializeField] TMP_Text guessingNumber;
    [SerializeField] Shooting shooting;

    public void bettingButton(int bet)
    {
        bettingAmount = bet;
    }

    public void bettingButtonTwo(string betName)
    {
        bettingName = betName;
    }

    void OnEnable()
    {
        guessingNumber.text = "" + Random.Range(0, 11);
        shooting = GameObject.Find("Player").GetComponent<Shooting>();
    }

    public void letsPlay(bool higher)
    {
        shooting.updateAmmoNegative(bettingName);
    }
}
