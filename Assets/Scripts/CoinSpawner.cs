using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] Transform[] positions;
    [SerializeField] private int respawnTime;
    [SerializeField] private float coinChance;

    void Start()
    {
        StartCoroutine(CoroutineCoins());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCoins()
    {
        Debug.Log("Spawning coin... maybe not!");
        int randomPos = Random.Range(0, positions.Length);
        float randomNumber = Random.Range(0, 101);
        if(randomNumber <= coinChance)
        {
            Instantiate(coin, positions[randomPos].position, Quaternion.identity);
        }
        Debug.Log(randomNumber);
    }

    IEnumerator CoroutineCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnCoins();
        }

    }
}
