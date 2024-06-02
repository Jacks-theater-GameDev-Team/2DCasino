using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blackjack : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool beingTouched;

    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            beingTouched = true;
            print("Player is touching blackjack");
            SceneManager.LoadScene("Blackjack");
        }
    }
}
