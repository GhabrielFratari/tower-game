using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarAgarra : MonoBehaviour
{
    public GameObject agarrasPrefabs;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coroutineAgarras());
    }

    private void spawnAgarra() {
        GameObject a = Instantiate(agarrasPrefabs) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
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
