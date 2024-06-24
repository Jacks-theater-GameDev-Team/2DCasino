using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBulletBehavior : MonoBehaviour
{
    [SerializeField] PlayerBehavior playerBehavior;

    [SerializeField] private int damage;
    [SerializeField] private Vector3 target;

    private void OnEnable()
    {
        if (damage == 0 ) { damage = 1; }
        playerBehavior = GameObject.Find("Player").GetComponent<PlayerBehavior>();
        target = GameObject.Find("Player").transform.position;

        StartCoroutine(Destroy());
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerBehavior.takeDamage(damage);
            Destroy(gameObject);
        }

        print("hello");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
