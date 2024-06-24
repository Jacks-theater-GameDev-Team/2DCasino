using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehavior : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;

    // Start is called before the first frame update
    public void backToMenu()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void toTheCredits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void menuTime()
    {
        SceneManager.LoadScene("Main Menu");
    }
}