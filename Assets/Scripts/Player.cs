using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;


    Rigidbody2D myRigidBody;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stone")
        {
            Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
            myRigidBody.bodyType = RigidbodyType2D.Kinematic;
            transform.position = new Vector2(transform.position.x, other.gameObject.transform.position.y);
            myRigidBody.velocity = otherRB.velocity;
        }

    }

    void JumpUp()
    {
        if(myRigidBody.bodyType == RigidbodyType2D.Kinematic)
        {
            myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            myRigidBody.velocity += new Vector2(0f, jumpForce);
        }
    }

}
