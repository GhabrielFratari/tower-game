using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float speed;
    Transform myTransform;
    private float xPos;
    private float lastPos;
    private void Awake()
    {
        myTransform = transform;
        lastPos = 0f;
    }
    
    void LateUpdate()
    {
        CheckPlayerPosition();
        Vector3 targetPos = new Vector3(xPos, myTransform.position.y, myTransform.position.z);
        myTransform.position = Vector3.Lerp(myTransform.position, targetPos, speed * Time.deltaTime);
        if(myTransform.position == targetPos) lastPos = myTransform.position.x; 

    }

    void CheckPlayerPosition()
    {
        if(player.velocity.x < 0f)
        {
            xPos = -0.15f;
        }
        else if (player.velocity.x > 0f)
        {
            xPos = 0.15f;
        }
    }
}
