using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private AmmoUIBehavior ammoUIBehavior;
    [SerializeField] private GameObject[] bullets;

    [SerializeField] private int two;
    [SerializeField] private int five;
    [SerializeField] private int ten;
    [SerializeField] private int twenty;
    [SerializeField] private int fifty;

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

        if (ammoUIBehavior.damageCounter == 0)
        {
            createBullet(rotation);
        }

        if (ammoUIBehavior.damageCounter == 1 && two != 0)
        {
            createBullet(rotation);
        }

        if (ammoUIBehavior.damageCounter == 2 && five != 0)
        {
            createBullet(rotation);
        }

        if (ammoUIBehavior.damageCounter == 3 && ten != 0)
        {
            createBullet(rotation);
        }

        if (ammoUIBehavior.damageCounter == 4 && twenty != 0)
        {
            createBullet(rotation);
        }

        if (ammoUIBehavior.damageCounter == 5 && two != 0)
        {
            createBullet(rotation);
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void updateAmmo(string ammoType)
    {
        if (ammoType == "two")
        {
            two++;
        }

        if (ammoType == "five")
        {
            five++;
        }

        if (ammoType == "ten")
        {
            ten++;
        }

        if (ammoType == "twenty")
        {
            twenty++;
        }

        if (ammoType == "fifty")
        {
            fifty++;
        }
    }

    public void updateAmmoNegative(string ammoType)
    {
        if (ammoType == "two")
        {
            two--;
        }

        if (ammoType == "five")
        {
            five--;
        }

        if (ammoType == "ten")
        {
            ten--;
        }

        if (ammoType == "twenty")
        {
            twenty--;
        }

        if (ammoType == "fifty")
        {
            fifty--;
        }
    }

    void createBullet(Quaternion rotation)
    {
        GameObject bullet = Instantiate(bullets[ammoUIBehavior.damageCounter], transform.position, rotation);
        bullet.name = bullets[ammoUIBehavior.damageCounter].name;
    }
}
