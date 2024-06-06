using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehavior : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float size;

    // Start is called before the first frame update
    void Awake()
    {
        if (speed == 0)
        {
            speed = 2f;
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GameObject[] otherBullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var otherBullet in otherBullets)
        {
            Physics2D.IgnoreCollision(otherBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
                    int.TryParse(gameObject.name.ToString(), out damage);
            var enemyBehavior = collision.gameObject.GetComponent<EnemyBehavior>();
            enemyBehavior.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
