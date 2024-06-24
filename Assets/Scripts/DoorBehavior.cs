using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject nextlevel;

    [SerializeField] private GameObject nextRoom;
    [SerializeField] private GameObject thisRoom;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (nextlevel == null) { print("Set the next level idiot"); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            activateLevel();
        }
    }

    public void activateLevel()
    {
        thisRoom.SetActive(false);
        nextRoom.SetActive(true);
    }
}
