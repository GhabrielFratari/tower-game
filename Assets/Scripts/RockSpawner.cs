using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] rocksPrefabs;
    [SerializeField] float respawnTime = 1.0f;
    [SerializeField] GameObject spawningPoint;
    [SerializeField] float[] positions;
    float lastPosition = 0;

    void Start()
    {
        StartCoroutine(coroutineAgarras());
    }

    private void spawnAgarra() {
        int rand = Random.Range(0, rocksPrefabs.Length);
        int randomPos = Random.Range(0, positions.Length);

        GameObject a = Instantiate(rocksPrefabs[rand]) as GameObject;

        if (lastPosition != 0)
        {
            float[] newPositions = { 0, lastPosition };
            int newRandomPos = Random.Range(0, newPositions.Length);
            a.transform.position = new Vector2(newPositions[newRandomPos], spawningPoint.transform.position.y);
            lastPosition = newPositions[newRandomPos];
        }
        else
        {
            a.transform.position = new Vector2(positions[randomPos], spawningPoint.transform.position.y);
            lastPosition = positions[randomPos];
        }
    }
    IEnumerator coroutineAgarras()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnAgarra();
        }
       
    }
}
