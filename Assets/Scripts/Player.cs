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

    float playerPosition;
    bool up = false;
    bool isDead = false;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerUpOnAir();
        PlayerFalling();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stone" && !isDead)
        {
            if (playerPosition == other.gameObject.transform.position.x && up)
            {
                PlayerLanding(other);
            }
            else if (playerPosition != other.gameObject.transform.position.x)
            {
                PlayerLanding(other);
            }
            else if (myRigidBody.velocity.y < Mathf.Epsilon)
            {
                PlayerLanding(other);
            }
        }

        if(other.tag == "FireBall" || other.tag == "Dragon")
        {
            isDead = true;
            myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        }

    }

    void OnJumpUp(InputValue value)
    {
        if (value.isPressed)
        {
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                playerPosition = transform.position.x;
                up = true;
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
                playerPosition = transform.position.x;
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
                playerPosition = transform.position.x;
                myAnimator.SetBool("isLanding", false);
                myAnimator.SetBool("isJumping", true);
                myRigidBody.bodyType = RigidbodyType2D.Dynamic;
                myRigidBody.velocity += new Vector2(xForce, jumpForce);
            }
        }
    }

    void PlayerLanding(Collider2D other)
    {
        myAnimator.SetBool("isFalling", false);
        myAnimator.SetBool("isUpOnAir", false);
        myAnimator.SetBool("isLanding", true);
        Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
        myRigidBody.bodyType = RigidbodyType2D.Kinematic;
        transform.position = new Vector2(other.gameObject.transform.position.x,
            other.gameObject.transform.position.y);
        myRigidBody.velocity = otherRB.velocity;
        up = false;
        playerPosition = transform.position.x;
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
