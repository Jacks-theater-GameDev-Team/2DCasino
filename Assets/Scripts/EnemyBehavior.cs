using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject door;
    [SerializeField] private PlayerBehavior playerBehavior;
    [SerializeField] private GameObject[] rewards;

    void Update()
    {
        if (door == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 0.01f);
        }
    }

    private void Start()
    {
        playerBehavior = GameObject.Find("Player").GetComponent<PlayerBehavior>();
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //play death animation

            //Open door if this was the boss
            if (door != null) { door.SetActive(true); }

            int rewardNumber = Random.Range(0, 6);
            GameObject reward = Instantiate(rewards[rewardNumber], transform.position, rewards[rewardNumber].transform.rotation);
            reward.name = rewards[rewardNumber].name;

            Destroy(gameObject);
        }
        else
        {
            //play damage animation
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            playerBehavior.takeDamage(1);
        }
    }
}
