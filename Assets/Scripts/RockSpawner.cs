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
    int lastPositionCounter1 = 0;
    int lastPositionCounter2 = 0;
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
            Vector2 currentPosition = new Vector2(newPositions[newRandomPos], spawningPoint.transform.position.y);
            a.transform.position = currentPosition;
            if (lastPosition == currentPosition.x && lastPositionCounter2 < 2)
            {
                lastPositionCounter2++;
                lastPosition = currentPosition.x;
            }
            else if(lastPosition == currentPosition.x)
            {
                lastPositionCounter2 = 0;
                lastPositionCounter2++;
                currentPosition = new Vector2(0, spawningPoint.transform.position.y);
                a.transform.position = currentPosition;
                lastPosition = 0;
            }
            else
            {
                lastPositionCounter2 = 0;
                lastPosition = currentPosition.x;
            }


        }
        else
        {
            Vector2 currentPosition = new Vector2(positions[randomPos], spawningPoint.transform.position.y);
            a.transform.position = currentPosition;
            if (lastPosition == currentPosition.x  && lastPositionCounter1 < 2)
            {
                lastPositionCounter1++;
                lastPosition = currentPosition.x;
            }
            else if(lastPosition == currentPosition.x)
            {
                lastPositionCounter1 = 0;
                lastPositionCounter1++;
                float[] newPositions = { -1.5f, 1.5f };
                int newRandomPos = Random.Range(0, newPositions.Length);
                currentPosition = new Vector2(newPositions[newRandomPos], spawningPoint.transform.position.y);
                a.transform.position = currentPosition;
                lastPosition = currentPosition.x;
            }
            else
            {
                lastPositionCounter1 = 0;
                lastPosition = currentPosition.x;
            }
            
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
