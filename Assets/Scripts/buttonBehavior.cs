using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBehavior : MonoBehaviour
{
    [SerializeField] private Shooting shooting;
    [SerializeField] private string buttonType;

    private void OnEnable()
    {
        shooting = GameObject.Find("Player").GetComponent<Shooting>();
    }

    void Update()
    {

    }
}
