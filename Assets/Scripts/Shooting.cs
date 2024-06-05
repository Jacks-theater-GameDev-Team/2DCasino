using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private AmmoUIBehavior ammoUIBehavior;
    [SerializeField] private GameObject[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        ammoUIBehavior = GameObject.Find("AmmoBorder").GetComponent<AmmoUIBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        var rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // if (ammo != 0) {
        print(ammoUIBehavior.damageCounter);
        Instantiate(bullets[ammoUIBehavior.damageCounter], transform.position, rotation);
        // } else {
        //    play empty gun sound
        // }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
