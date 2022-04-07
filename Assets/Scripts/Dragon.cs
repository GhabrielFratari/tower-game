using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Dragon : MonoBehaviour
{
    [SerializeField] private float[] positions;
    [SerializeField] float moveSpeed = 1;
    private bool canMove = false;
    private int randomIndex;

    void Start()
    {
        FunctionTimer.Create(CanMove, 2f);
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
        Vector3 targetPosition = new Vector3(positions[randomIndex], transform.position.y);
        float delta = moveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        if (transform.position == targetPosition)
        {
            FunctionTimer.Create(CanMove, 3f);
            canMove = false;
            Shoot();
        }

    }

    private void CanMove()
    {
        randomIndex = Random.Range(0, positions.Length);
        canMove = true;
    } 

    private void Shoot()
    {
        Debug.Log("Shooting");
    }

}
