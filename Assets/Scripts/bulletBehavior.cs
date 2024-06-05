using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        //damage = int.Parse(gameObject.name); - This doesn't work, need to find another way to get Prefab name to Int
        if (bulletSpeed == 0)
        {
            bulletSpeed = 2f;
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void Update()
    {
        transform.position -= transform.right * bulletSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            var enemyBehavior = collision.gameObject.GetComponent<EnemyBehavior>();
            enemyBehavior.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
