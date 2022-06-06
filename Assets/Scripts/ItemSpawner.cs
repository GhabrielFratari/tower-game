using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;
    [SerializeField] Transform[] positions;

    [Header("Respawn Time")]
    [SerializeField] private int minTime;
    [SerializeField] private int maxTime;

    [Header("Items Chance")]
    [SerializeField] private float shieldChance;
    [SerializeField] private float wingsChance;
    [SerializeField] private float superJumpChance;
    [SerializeField] private float magnetChance;
    [SerializeField] private float nothingChance;

    void Start()
    {
        wingsChance = wingsChance + shieldChance;
        superJumpChance = superJumpChance + wingsChance;
        magnetChance = magnetChance + superJumpChance;
        StartCoroutine(CoroutinePowerUps());
    }

    private void SpawnPowerUp()
    {
        int randomPos = Random.Range(0, positions.Length);
        float randomNumber = Random.Range(0, 101);
        //Debug.Log("Random Number is: " + randomNumber);
        if (randomNumber <= shieldChance)
        {
            //spawn shield
            GameObject a = Instantiate(powerUps[0], positions[randomPos].transform.position, Quaternion.identity);
            //Debug.Log("shield");
        }
        else if (randomNumber <= wingsChance && randomNumber > shieldChance)
        {
            //spawn wings
            GameObject a = Instantiate(powerUps[1], positions[randomPos].transform.position, Quaternion.identity);
            //Debug.Log("wings");
        }
        else if (randomNumber <= superJumpChance && randomNumber > wingsChance)
        {
            //spawn super jump
            GameObject a = Instantiate(powerUps[2], positions[randomPos].transform.position, Quaternion.identity);
            //Debug.Log("super jump");
        }
        /*else if (randomNumber <= magnetChance && randomNumber > superJumpChance)
        {
            //spawn magnet
            GameObject a = Instantiate(powerUps[3], positions[randomPos].transform.position, Quaternion.identity);
            //Debug.Log("magnet");
        }*/
        else
        {
            //nothing happens :)
            //Debug.Log("nothing");
        }
    }



    IEnumerator CoroutinePowerUps()
    {
        while (true)
        {
            int respawnTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(respawnTime);
            //Debug.Log(respawnTime);
            SpawnPowerUp();
        }

    }
}
