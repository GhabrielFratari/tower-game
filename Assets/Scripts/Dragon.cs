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
    Vector3 moveTotargetPosition;
    Vector3 outOfScreenTarget;
    Transform myTransform;

    void Awake()
    {
        myTransform = transform;
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
        moveTotargetPosition = new Vector3(positions[randomIndex], -6.52f);
        float delta = moveSpeed * Time.deltaTime;
        myTransform.position = Vector2.MoveTowards(myTransform.position, moveTotargetPosition, delta);
        if (myTransform.position == moveTotargetPosition)
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
        if (myTransform.position.x == 0f || myTransform.position.x == 1.5f || myTransform.position.x == -1.5f)
        {
            GameObject instance = Instantiate(fireBallPrefab, myTransform.position, Quaternion.identity);
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
        outOfScreenTarget = new Vector3(outOfScreenPos.transform.position.x, outOfScreenPos.transform.position.y);
        myTransform.position = Vector2.MoveTowards(myTransform.position, outOfScreenTarget, delta);
    }

    public GameObject GetOutOfScreenPos()
    {
        return outOfScreenPos;
    }
}
