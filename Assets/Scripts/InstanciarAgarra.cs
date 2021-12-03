using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarAgarra : MonoBehaviour
{
    [SerializeField] GameObject[] agarrasPrefabs;
    [SerializeField] float respawnTime = 1.0f;
    private Vector2 screenBounds;
    [SerializeField] float[] positions;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coroutineAgarras());
    }

    private void spawnAgarra() {
        int rand = Random.Range(0, agarrasPrefabs.Length);
        int randomPos = Random.Range(0, positions.Length);

        GameObject a = Instantiate(agarrasPrefabs[rand]) as GameObject;
        a.transform.position = new Vector2(positions[randomPos], screenBounds.y * 2);
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
