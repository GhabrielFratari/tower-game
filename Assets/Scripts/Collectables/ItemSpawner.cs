using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;
    [SerializeField] Transform[] positions;

    [Header("Respawn Time")]
    [SerializeField] private int minTime;
    [SerializeField] private int maxTime;

    [Header("Items Chance")]
    private float shieldChance = 0;
    private float wingsChance = 0;
    private float superJumpChance = 0;
    private float maxChance = 66f;
    private float[] powerUpChances = {0, 0, 0};

    bool[] hasPowerUps = {false, false, false};
    private void Awake()
    {
        hasPowerUps[0] = SaveManager.Instance.Load().shieldOwned;
        hasPowerUps[1] = SaveManager.Instance.Load().wingsOwned;
        hasPowerUps[2] = SaveManager.Instance.Load().superJump;
    }

    void Start()
    {
        CheckPowerUpOwned();
        
        StartCoroutine(CoroutinePowerUps());
        FunctionTimer.Create(SpawnPowerUp, 5);
    }

    private void SpawnPowerUp()
    {
        int randomPos = Random.Range(0, positions.Length);
        float randomNumber = Random.Range(0, 101);
        Debug.Log("Change %" + randomNumber);
        if (randomNumber <= shieldChance)
        {
            //spawn shield
            Instantiate(powerUps[0], positions[randomPos].transform.position, Quaternion.identity);
        }
        else if (randomNumber <= wingsChance && randomNumber > shieldChance)
        {
            //spawn wings
            Instantiate(powerUps[1], positions[randomPos].transform.position, Quaternion.identity);
        }
        else if (randomNumber <= superJumpChance && randomNumber > wingsChance)
        {
            //spawn super jump
            Instantiate(powerUps[2], positions[randomPos].transform.position, Quaternion.identity);
        }
    }

    void CheckPowerUpOwned()
    {
        int j = 0;
        for(int i = 0; i < 3; i++)
        {
            if (hasPowerUps[i])
            {
                j++;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (hasPowerUps[i])
            {
                powerUpChances[i] = maxChance / j;
            }
        }
        shieldChance = powerUpChances[0];
        wingsChance = powerUpChances[1] + shieldChance;
        superJumpChance = powerUpChances[2] + wingsChance;

        Debug.Log(shieldChance);
        Debug.Log(wingsChance);
        Debug.Log(superJumpChance);
    }



    IEnumerator CoroutinePowerUps()
    {
        while (true)
        {
            int respawnTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(respawnTime);
            SpawnPowerUp();
        }

    }
}
