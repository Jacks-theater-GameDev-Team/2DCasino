using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    [SerializeField] private bool roll;
    [SerializeField] private bool rollCooldown;
    [SerializeField] private float rollSpeed = 2f;
    [SerializeField] private float rollSlow = 0.75f;


    [SerializeField] public float runSpeed = 2f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        roll = false;
        rollCooldown = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && roll == false && rollCooldown == false)
        {
            roll = true;
            rolling();
        }

        if (!roll) {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        if (!roll)
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }

    void rolling()
    {
        StartCoroutine(rollTimer());
    }

    IEnumerator rollTimer()
    {
        rollCooldown = true;
        body.velocity = new Vector2(horizontal * runSpeed * rollSpeed, vertical * runSpeed * rollSpeed);
        yield return new WaitForSeconds(.2f);
        body.velocity = new Vector2(horizontal * runSpeed * rollSlow, vertical * runSpeed * rollSlow);
        yield return new WaitForSeconds(1f);
        roll = false;
        yield return rollCooldown = false;
        
    }
}
