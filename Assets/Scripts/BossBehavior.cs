using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletPoint;

    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.Find("Player");
        if (bullet == null) { print("Set bullet prefab in Boss, please"); }
        if (bulletPoint == null) { print("Set the bulletPoint in Boss, please"); }
        StartCoroutine(shoot());
    }

    private void Update()
    {
        transform.LookAt(player.transform);
    }

    IEnumerator shoot()
    {
        Instantiate(bullet, bulletPoint.transform.position, bullet.transform.rotation);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(shoot());
    }
}
