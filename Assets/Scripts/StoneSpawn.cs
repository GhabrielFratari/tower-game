using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{

    public GameObject quad;
    Rigidbody rb;
    Vector2 velocity;
    float x, y;

    TowerMove tower;

    private void Awake()
    {
        x = 122f;
        y = 252;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(quad, transform.position, Quaternion.identity);
        tower = GetComponent<TowerMove>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y * tower.velocidade);
    }
}
