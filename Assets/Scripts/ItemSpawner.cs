using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;


    void Start()
    {
        Instantiate(powerUps[0], transform.position, Quaternion.identity);
       
    }

    void Update()
    {
        
    }
}
