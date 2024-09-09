using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandleTutorial : MonoBehaviour
{
    [SerializeField] private Transform swipeUp;
    [SerializeField] private Transform swipeDown;
    [SerializeField] private Transform swipeLeft;
    [SerializeField] private Transform swipeRight;
    [SerializeField] private int moveDistance;
    [SerializeField] private float moveSpeed;
    private Vector3 initialPosition;
    bool canMove = false;
    private void Start() 
    {
        initialPosition = swipeUp.transform.position;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || canMove)
        {
            canMove = true;
            MoveUp();
        }
        
    }

    private void MoveUp()
    {
        swipeUp.gameObject.SetActive(true);
        Vector3 target = new Vector3(initialPosition.x, initialPosition.y + moveDistance, initialPosition.z);
        swipeUp.position = Vector3.MoveTowards(swipeUp.position, target, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(swipeUp.position, target) < 0.001f)
        {
            target *= -1f;
            //swipeUp.gameObject.SetActive(false);
            canMove = false;
            //swipeUp.position = initialPosition;
        }
    }
    private void MoveDown()
    {
        swipeDown.gameObject.SetActive(true);
        Vector3 target = new Vector3(initialPosition.x, initialPosition.y - moveDistance, initialPosition.z);
        swipeDown.position = Vector3.MoveTowards(swipeDown.position, target, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(swipeDown.position, target) < 0.001f)
        {
            target *= -1f;
            swipeDown.gameObject.SetActive(false);
            canMove = false;
            swipeDown.position = initialPosition;
        }
    }
    private void MoveLeft()
    {
        swipeLeft.gameObject.SetActive(true);
        Vector3 target = new Vector3(initialPosition.x - moveDistance, initialPosition.y, initialPosition.z);
        swipeLeft.position = Vector3.MoveTowards(swipeLeft.position, target, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(swipeLeft.position, target) < 0.001f)
        {
            target *= -1f;
            swipeLeft.gameObject.SetActive(false);
            canMove = false;
            swipeLeft.position = initialPosition;
        }
    }
    private void MoveRight()
    {
        swipeRight.gameObject.SetActive(true);
        Vector3 target = new Vector3(initialPosition.x + moveDistance, initialPosition.y, initialPosition.z);
        swipeRight.position = Vector3.MoveTowards(swipeRight.position, target, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(swipeRight.position, target) < 0.001f)
        {
            target *= -1f;
            swipeRight.gameObject.SetActive(false);
            canMove = false;
            swipeRight.position = initialPosition;
        }
    }
}
