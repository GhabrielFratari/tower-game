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
    [SerializeField] private float flyingSpeed = 5f;
    [SerializeField] private float movingToPointSpeed = 5f;

    [Header("References")]
    [SerializeField] CapsuleCollider2D handsCollider;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;
    [SerializeField] ParticleSystem dustParticles;
    [SerializeField] ParticleSystem wingsExplosion;
    [SerializeField] GameObject shieldObject;
    [SerializeField] GameObject wingsObject;
    [SerializeField] GameObject body;
    [SerializeField] Transform flyingPoint;
    [SerializeField] Transform flyingPointLeft;
    [SerializeField] Transform flyingPointRight;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    AnimationClip jumpClip;
    AnimationEvent jumpEvent;
    ScoreSystem scoreSystem;

    private float playerPosition;
    private float gravity;
    private Vector3 currentPosition;
    private bool up = false;
    private bool isDead = false;
    private bool isOtherButtonPressed = false;
    private bool hit = false;
    private bool shield = false;
    private bool wings = false;
    private bool canFly = false;
    private bool canMove = true;
    private bool right, left, mid = false;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        scoreSystem = GetComponent<ScoreSystem>();
        gravity = myRigidBody.gravityScale;
    }

    private void Update()
    {
       
        if (canFly)
        {
            myAnimator.SetBool("isFalling", false);
            myAnimator.SetBool("isUpOnAir", false);
            myAnimator.SetBool("isFlying", true);
            if (left)
            {
                PlayerFlying(-1);
            }
            else if (right)
            {
                PlayerFlying(1);
            }
            else if(mid)
            {
                PlayerFlying(0);
            }
        }
        else
        {
            PlayerUpOnAir();
            PlayerFalling();
        }
        
        
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
            if (wings) WingsOff();
            PlayerDeath();
        }

        if(other.tag == "ShieldCollectable" && !shield)
        {
            Instantiate(shieldObject, body.transform.position, Quaternion.identity, body.gameObject.transform);
        }

        if (other.tag == "WingsCollectable" && !isDead && !wings)
        {
            PlayerCanFly();
            Instantiate(wingsObject, body.gameObject.transform);
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
            else if (canFly)
            {
                if (transform.position.x == 0f)
                {
                    left = true;
                }
                else if(transform.position.x == 1.5f)
                {
                    mid = true;
                }

                isOtherButtonPressed = false;
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
            else if (canFly)
            {
                if(transform.position.x == 0f)
                {
                    right = true;
                }
                else if (transform.position.x == -1.5f)
                {
                    mid = true;
                }
                isOtherButtonPressed = false;
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
        myAnimator.SetBool("isFlying", false);
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
            myAnimator.SetBool("isUpOnAir", false);
            myAnimator.SetBool("isFlying", false);
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

    public void PlayerFlying(int direction)
    {
        Vector3 targetPosition = new Vector3(flyingPointRight.position.x * direction, flyingPointRight.position.y);
        float delta = flyingSpeed * Time.deltaTime;
        if (transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        }
        else
        {
            if(direction == 1)
            {
                right = false;
            }
            else if(direction == -1)
            {
                left = false;
            }
            else
            {
                mid = false;
            }
        }
    }

    void PlayerCanFly()
    {
        canMove = true;
        wings = true;
        canFly = true;
        isOtherButtonPressed = false;
        handsCollider.enabled = false;
        myRigidBody.bodyType = RigidbodyType2D.Kinematic;
        myRigidBody.gravityScale = 0f;
        myRigidBody.velocity = new Vector2(0, 0);
    }
    public void MoveToFlyingPoint()
    {
        Vector3 targetPosition = new Vector3(flyingPoint.transform.position.x, flyingPoint.transform.position.y);
        float delta = movingToPointSpeed * Time.deltaTime;
        if (transform.position != targetPosition && canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        }
        else
        {
            canMove = false;
        }
    }

    void PlayerDeath()
    {
        isDead = true;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myRigidBody.gravityScale = gravity;
        myAnimator.SetTrigger("Dying");
        if (myRigidBody.velocity.x > 0 && !hit)
        {
            myRigidBody.velocity = new Vector2(0,0);
            myRigidBody.velocity = deathKick;
            hit = true;
        }
        else if(myRigidBody.velocity.x < 0 && !hit)
        {
            myRigidBody.velocity = new Vector2(0, 0);
            deathKick.x = -deathKick.x;
            myRigidBody.velocity = deathKick;
            hit = true;
        }
        else if(!hit)
        {
            myRigidBody.velocity = new Vector2(0, 0);
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
    void PlayWingsExplosion()
    {
        if (wingsExplosion != null)
        {
            ParticleSystem instance = Instantiate(wingsExplosion, transform.position, wingsExplosion.transform.rotation, body.transform);
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

    public void WingsOff()
    {
        myAnimator.SetBool("isFlying", false);
        PlayWingsExplosion();
        isOtherButtonPressed = false;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        handsCollider.enabled = true;
        myRigidBody.gravityScale = gravity;
        canFly = false;
        wings = false;
    }
}
