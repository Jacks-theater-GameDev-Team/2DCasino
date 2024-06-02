using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnCollisionEnter(Collision collision)
    {
                    beingTouched = true;
            print("Being touched");
        if (collision.gameObject.tag == "Player")
        {
            beingTouched = true;
            print("Player is touching blackjack");
        }
    }
}
