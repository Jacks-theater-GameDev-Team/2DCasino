using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBehavior : MonoBehaviour
{
    [SerializeField] Shooting shooting;

    private void Start()
    {
        shooting = GameObject.Find("Player").GetComponent<Shooting>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shooting.updateAmmo(gameObject.name);
            Destroy(gameObject);
        }
    }
}
