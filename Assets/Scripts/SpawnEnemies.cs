using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] spawnLocations;

    // Start is called before the first frame update
    void OnEnable()
    {
        int j = 0;
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            Instantiate(enemies[Random.Range(0,4)], spawnLocations[i].transform.position, enemies[j].transform.rotation);
        }
    }
}
