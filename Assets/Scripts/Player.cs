using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float xForce = 2;
    [SerializeField] private Vector2 deathKick = new Vector2(10f, 10f);

    [Header("References")]
    [SerializeField] CapsuleCollider2D handsCollider;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;
    [SerializeField] ParticleSystem dustParticles;
    //[SerializeField] Shield shieldRef;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    AnimationClip jumpClip;
    AnimationEvent jumpEvent;
    ScoreSystem scoreSystem;

    private float playerPosition;
    private bool up = false;
    private bool isDead = false;
    private bool isOtherButtonPressed = false;
    private bool hit = false;
    private bool shield = false;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        scoreSystem = GetComponent<ScoreSystem>();
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
            else
            {
                other.GetComponent<Rock>().MissPoints();
            }
        }

        if(other.tag == "FireBall" && !shield)
        {
            PlayerDeath();
        }

    }

    void OnJumpUp(InputValue value)
    {
        if (value.isPressed && !isOtherButtonPressed)
        {
            isOtherButtonPressed = true;
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                up = true;
                PlayerJumping(0f);
            }
        }
    }

    void OnJumpLeft(InputValue value)
    {
        if (value.isPressed && !isOtherButtonPressed)
        {
            isOtherButtonPressed = true;
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                PlayerJumping(-xForce);
            }
        }
    }

    void OnJumpRight(InputValue value)
    {
        if (value.isPressed && !isOtherButtonPressed)
        {
            isOtherButtonPressed = true;
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                PlayerJumping(xForce);
            }
        }
    }

    void PlayerLanding(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(landingSound, Camera.main.transform.position, 0.15f);
        isOtherButtonPressed = false;
        other.GetComponent<Rock>().AddPoints();
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

    void PlayerJumping(float xValue)
    {
        PlayDustEffect();
        AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position, 0.25f);
        playerPosition = transform.position.x;
        myAnimator.SetBool("isLanding", false);
        myAnimator.SetBool("isJumping", true);
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myRigidBody.velocity += new Vector2(xValue, jumpForce);
    }

    void PlayerDeath()
    {
        isDead = true;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myAnimator.SetTrigger("Dying");
        if (myRigidBody.velocity.x > 0 && !hit)
        {
            myRigidBody.velocity = deathKick;
            hit = true;
        }
        else if(myRigidBody.velocity.x < 0 && !hit)
        {
            deathKick.x = -deathKick.x;
            myRigidBody.velocity = deathKick;
            hit = true;
        }
        else if(!hit)
        {
            deathKick.x = 0;
            myRigidBody.velocity = deathKick;
            hit = true;
        }
    }
    void PlayDustEffect()
    {
        if (dustParticles != null)
        {
            ParticleSystem instance = Instantiate(dustParticles, transform.position, dustParticles.transform.rotation);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }

    public void ShieldOn()
    {
            shield = true;
    }
    public void ShieldOff()
    {
        shield = false;
    }
}
