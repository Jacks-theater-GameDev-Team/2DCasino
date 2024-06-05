using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoUIBehavior : MonoBehaviour
{
    [SerializeField] private GameObject ammoUI;
    [SerializeField] private bool cooldown;
    [SerializeField] private int[] damage;
    public int damageCounter;

    [SerializeField] private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        damage = new int[] { 1, 2, 5, 10, 20, 50 };
        ammoUI = GameObject.Find("AmmoUI");
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.mouseScrollDelta.y;
        if (vertical != 0 && cooldown != true)
        {
            cooldown = true;
            damageCounter -= Mathf.RoundToInt(vertical);

            if (damageCounter < 0 || damageCounter > (damage.Length - 1))
            {
                ammoUI.transform.position -= new Vector3(0, vertical * 0.688f * 2, 0);
                damageCounter += Mathf.RoundToInt(vertical);
            }

            ammoUI.transform.position += new Vector3 (0, vertical * 0.688f * 2, 0);
            StartCoroutine(scrollCooldown());

            print(damage[damageCounter]);
        }
    }

    IEnumerator scrollCooldown()
    {
        yield return new WaitForSeconds(.3f);
        yield return cooldown = false;
    }
}
