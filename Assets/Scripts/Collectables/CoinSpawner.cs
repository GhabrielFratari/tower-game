using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject coinDouble;
    [SerializeField] Transform[] positions;
    [SerializeField] private int respawnTime;
    [SerializeField] private float coinChance;
    [SerializeField] private float doubleCoinChance;
    bool hasDoubleCoin = false;
    private float doubleCoinRealChance = 0;
    void Start()
    {
        CheckDoubleCoinOwned();
        StartCoroutine(CoroutineCoins());
    }

    void CheckDoubleCoinOwned()
    {
        hasDoubleCoin = SaveManager.Instance.Load().doubleCoin;
        if (hasDoubleCoin)
        {
            doubleCoinRealChance = coinChance + doubleCoinChance;
        }

    }

    void SpawnCoins()
    {
        //Debug.Log("Spawning coin... maybe not!");
        int randomPos = Random.Range(0, positions.Length);
        float randomNumber = Random.Range(0, 101);
        if(randomNumber <= coinChance)
        {
            Instantiate(coin, positions[randomPos].position, Quaternion.identity);
        }
        else if (randomNumber <= doubleCoinRealChance && randomNumber > coinChance)
        {
            Instantiate(coinDouble, positions[randomPos].position, Quaternion.identity);
        }
        //Debug.Log("coin chance " + randomNumber);
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
