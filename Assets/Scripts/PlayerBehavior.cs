using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int roomNumber;
    [SerializeField] private GameObject[] nextLevelPoints;
    [SerializeField] private GameObject joker;
    [SerializeField] private DoorBehavior doorBehavior;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        roomNumber = 0;
        if (nextLevelPoints == null) { print("Set the nextLevelPoints in player, idiot!"); }
        if (joker == null) { print("Set the Joker in player, idiot!"); }
    }
    
    public void updateRoomNumber()
    {
        roomNumber++;
        if (roomNumber == 9) { roomNumber = 1; }
        transform.position = nextLevelPoints[roomNumber].transform.position;
        if (roomNumber == 1)
        {
            joker.SetActive(true);
        }
        else
        {
            joker.SetActive(false);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            updateRoomNumber();
            health = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            updateRoomNumber();
        }
    }
}
