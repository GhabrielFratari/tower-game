using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Dragon : MonoBehaviour
{
    [SerializeField] private float[] positions;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private GameObject fireBallPrefab;
    [SerializeField] private float fireBallSpeed = 5f;
    [SerializeField] private float dragonMoveDelay = 5f;
    [SerializeField] private float shootingDelay = 1f;
    [SerializeField] private GameObject outOfScreenPos;

    private bool canMove = false;
    private int randomIndex;

    void Start()
    {

    }

    void Update()
    {
        if (canMove)
        {
            Move();
        }

    }

    private void Move()
    {
        Vector3 targetPosition = new Vector3(positions[randomIndex], -6.52f);
        float delta = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        if (transform.position == targetPosition)
        {
            FunctionTimer.Create(CanMove, dragonMoveDelay);
            canMove = false;
            FunctionTimer.Create(Shoot, shootingDelay);
            //Shoot();
        }

    }

    public void CanMove()
    {
        randomIndex = Random.Range(0, positions.Length);
        canMove = true;
    } 

    private void Shoot()
    {
        if (transform.position.x == 0f || transform.position.x == 1.5f || transform.position.x == -1.5f)
        {
            GameObject instance = Instantiate(fireBallPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * fireBallSpeed;
            }
        }
    }

    public void GoOutOfScreen()
    {
        canMove = false;
        float delta = moveSpeed * Time.deltaTime;
        Vector3 targetPosition = new Vector3(outOfScreenPos.transform.position.x, outOfScreenPos.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
    }

    public GameObject GetOutOfScreenPos()
    {
        return outOfScreenPos;
    }
}
