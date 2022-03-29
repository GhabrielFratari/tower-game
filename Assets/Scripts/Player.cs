using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float xForce = 2;

    [SerializeField] CapsuleCollider2D handsCollider;
    Rigidbody2D myRigidBody;
    Animator myAnimator;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    private void Update()
    {
        PlayerUpOnAir();
        PlayerFalling();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stone")
        {
            myAnimator.SetBool("isFalling", false);
            myAnimator.SetBool("isUpOnAir", false);
            myAnimator.SetBool("isLanding", true);
            Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
            myRigidBody.bodyType = RigidbodyType2D.Kinematic;
            transform.position = new Vector2(other.gameObject.transform.position.x,
                other.gameObject.transform.position.y);
            myRigidBody.velocity = otherRB.velocity;
        }

    }

    void OnJumpUp(InputValue value)
    {
        if (value.isPressed)
        {
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                myAnimator.SetBool("isLanding", false);
                myAnimator.SetBool("isJumping", true);
                myRigidBody.bodyType = RigidbodyType2D.Dynamic;
                myRigidBody.velocity += new Vector2(0f, jumpForce);
            }
        }
    }

    void OnJumpLeft(InputValue value)
    {
        if (value.isPressed)
        {
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                myAnimator.SetBool("isLanding", false);
                myAnimator.SetBool("isJumping", true);
                myRigidBody.bodyType = RigidbodyType2D.Dynamic;
                myRigidBody.velocity += new Vector2((xForce * -1), jumpForce);
            }
        }
    }

    void OnJumpRight(InputValue value)
    {
        if (value.isPressed)
        {
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                myAnimator.SetBool("isLanding", false);
                myAnimator.SetBool("isJumping", true);
                myRigidBody.bodyType = RigidbodyType2D.Dynamic;
                myRigidBody.velocity += new Vector2(xForce, jumpForce);
            }
        }
    }

    void PlayerUpOnAir()
    {
        bool verticalSpeedPositive = myRigidBody.velocity.y > Mathf.Epsilon;
        if(verticalSpeedPositive && !handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
        {
            myAnimator.SetBool("isJumping", false);
            myAnimator.SetBool("isUpOnAir", true);
        }
    }

    void PlayerFalling()
    {
        bool verticalSpeedNegative = myRigidBody.velocity.y < Mathf.Epsilon;
        if (verticalSpeedNegative && !handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
        {
            myAnimator.SetBool("isJumping", false);
            myAnimator.SetBool("isFalling", true);
        }
    }
}
