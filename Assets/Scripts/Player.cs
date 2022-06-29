using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.Utils;

public class Player : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float xForce = 2;
    [SerializeField] private Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] private float flyingSpeed = 5f;
    [SerializeField] private float movingToPointSpeed = 5f;
    [SerializeField] private float upForce = 10f;

    [Header("References")]
    [SerializeField] CapsuleCollider2D handsCollider;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landingSound;
    [SerializeField] AudioClip wingsSound;
    [SerializeField] AudioClip wingsPoofSound;
    [SerializeField] AudioClip boingSound;
    [SerializeField] AudioClip coinSound;
    [SerializeField] ParticleSystem dustParticles;
    [SerializeField] ParticleSystem wingsExplosion;
    [SerializeField] ParticleSystem superJumpFlash;
    [SerializeField] ParticleSystem shieldExplosion;
    [SerializeField] GameObject shieldObject;
    [SerializeField] GameObject wingsObject;
    [SerializeField] GameObject body;
    [SerializeField] Transform flyingPoint;
    [SerializeField] Transform flyingPointLeft;
    [SerializeField] Transform flyingPointRight;

    Rigidbody2D myRigidBody;
    CapsuleCollider2D playerCollider;
    Animator myAnimator;
    AnimationClip jumpClip;
    AnimationEvent jumpEvent;
    ScoreSystem scoreSystem;
    Vector3 flyTotargetPosition;
    Vector3 targetPosition;
    Camera mainCam;
    Transform myTransform;

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
    private bool dropping = false;
    private bool hasPowerUp = false;

    private void Awake()
    {
        myTransform = transform;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        gravity = myRigidBody.gravityScale;
        playerCollider = GetComponent <CapsuleCollider2D>();
        mainCam = Camera.main;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dropping)
        {
            dropping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Stone" && !isDead && !dropping)
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

        if(other.tag == "ShieldCollectable" && !shield && !wings)
        {
            Instantiate(shieldObject, body.transform.position, Quaternion.identity, body.gameObject.transform);
            hasPowerUp = true;
        }

        if (other.tag == "WingsCollectable" && !isDead && !wings)
        {
            PlayerCanFly();
            Instantiate(wingsObject, body.gameObject.transform);
            hasPowerUp = true;
        }
        if (other.tag == "UpCollectable" && !wings)
        {
            scoreSystem.AddToScore(50);
            SuperJump(other);
        }
        if(other.tag == "Coin")
        {
            AudioSource.PlayClipAtPoint(coinSound, mainCam.transform.position, 0.4f);
        }
    }

    public void JumpUp()
    {
        if (!isOtherButtonPressed)
        {
            isOtherButtonPressed = true;
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                up = true;
                PlayerJumping(0f);
            }
            else
            {
                isOtherButtonPressed = false;
            }
        }
    }

    public void JumpLeft()
    {
        if (!isOtherButtonPressed)
        {
            isOtherButtonPressed = true;
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                PlayerJumping(-xForce);
            }
            else if (canFly)
            {
                if (myTransform.position.x == 0f)
                {
                    left = true;
                    AudioSource.PlayClipAtPoint(wingsSound, mainCam.transform.position, 0.8f);
                    isOtherButtonPressed = false;
                }
                else if(myTransform.position.x == 1.5f)
                {
                    mid = true;
                    AudioSource.PlayClipAtPoint(wingsSound, mainCam.transform.position, 0.8f);
                    isOtherButtonPressed = false;
                }
                else
                {
                    isOtherButtonPressed = false;
                }
            }
        }
    }

    public void JumpRight()
    {
        if (!isOtherButtonPressed)
        {
            isOtherButtonPressed = true;
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                PlayerJumping(xForce);
            }
            else if (canFly)
            {
                if (myTransform.position.x == 0f)
                {
                    right = true;
                    AudioSource.PlayClipAtPoint(wingsSound, mainCam.transform.position, 0.8f);
                    isOtherButtonPressed = false;
                }
                else if (myTransform.position.x == -1.5f)
                {
                    mid = true;
                    AudioSource.PlayClipAtPoint(wingsSound, mainCam.transform.position, 0.8f);
                    isOtherButtonPressed = false;
                }
                else
                {
                    isOtherButtonPressed = false;
                }
            }
        }
    }
    public void Drop()
    {
        if (!isOtherButtonPressed)
        {
            isOtherButtonPressed = true;
            if (handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
            {
                PlayerDropping();
            }
            else
            {
                isOtherButtonPressed = false;
            }
        }
    }

    void PlayerLanding(Collider2D other)
    {
        AudioSource.PlayClipAtPoint(landingSound, mainCam.transform.position, 0.15f);
        isOtherButtonPressed = false;
        other.GetComponent<Rock>().AddPoints();
        myAnimator.SetBool("isFalling", false);
        myAnimator.SetBool("isUpOnAir", false);
        myAnimator.SetBool("isFlying", false);
        myAnimator.SetBool("isLanding", true);
        Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
        myRigidBody.bodyType = RigidbodyType2D.Kinematic;
        myTransform.position = new Vector2(other.gameObject.transform.position.x,
            other.gameObject.transform.position.y);
        myRigidBody.velocity = otherRB.velocity;
        up = false;
        playerPosition = myTransform.position.x;
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
        bool verticalSpeedNegative = myRigidBody.velocity.y < -1f;
        if (verticalSpeedNegative && !handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
        {
            handsCollider.enabled = true;
            myAnimator.SetBool("isUpOnAir", false);
            myAnimator.SetBool("isFlying", false);
            myAnimator.SetBool("isFalling", true);
        }
    }

    void PlayerJumping(float xValue)
    {
        PlayDustEffect();
        AudioSource.PlayClipAtPoint(jumpSound, mainCam.transform.position, 0.25f);
        playerPosition = myTransform.position.x;
        myAnimator.SetBool("isLanding", false);
        myAnimator.SetBool("isJumping", true);
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myRigidBody.velocity += new Vector2(xValue, jumpForce);
    }

    void PlayerDropping()
    {
        dropping = true;
        Debug.Log("Dropping!");
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myRigidBody.velocity = new Vector2(0, -jumpForce);
        isOtherButtonPressed = false;
    }

    public void PlayerFlying(int direction)
    {
        flyTotargetPosition = new Vector3(flyingPointRight.position.x * direction, flyingPointRight.position.y);
        float delta = flyingSpeed * Time.deltaTime;
        if (myTransform.position != flyTotargetPosition)
        {
            myTransform.position = Vector2.MoveTowards(myTransform.position, flyTotargetPosition, delta);
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
        StartCoroutine("WingsCoroutine");
    }
    public void MoveToFlyingPoint()
    {
        targetPosition = new Vector3(flyingPoint.transform.position.x, flyingPoint.transform.position.y);
        float delta = movingToPointSpeed * Time.deltaTime;
        if (myTransform.position != targetPosition && canMove)
        {
            myTransform.position = Vector2.MoveTowards(myTransform.position, targetPosition, delta);
        }
        else
        {
            canMove = false;
        }
    }

    void SuperJump(Collider2D other)
    {
        myTransform.position = new Vector2(other.transform.position.x, myTransform.position.y);
        AudioSource.PlayClipAtPoint(boingSound, mainCam.transform.position, 0.5f);
        PlaySuperJumpFlash();
        handsCollider.enabled = false;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        myRigidBody.velocity = new Vector2(0, 0);
        myRigidBody.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
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
            ParticleSystem instance = Instantiate(dustParticles, myTransform.position, dustParticles.transform.rotation);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }
    void PlayWingsExplosion()
    {
        if (wingsExplosion != null)
        {
            ParticleSystem instance = Instantiate(wingsExplosion, myTransform.position, wingsExplosion.transform.rotation, body.transform);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }
    void PlaySuperJumpFlash()
    {
        if (superJumpFlash != null)
        {
            ParticleSystem instance = Instantiate(superJumpFlash, myTransform.position, transform.rotation, body.transform);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }
    void PlayShieldExplosion()
    {
        if (shieldExplosion != null)
        {
            ParticleSystem instance = Instantiate(shieldExplosion, body.transform.position, transform.rotation);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }

    public void ShieldOn()
    {
        shield = true;
        playerCollider.enabled = false;
    }
    public void ShieldOff()
    {
        shield = false;
        playerCollider.enabled = true;
        hasPowerUp = false;
        AudioSource.PlayClipAtPoint(wingsPoofSound, mainCam.transform.position, 0.15f);
        PlayShieldExplosion();
    }

    void EnableCollider()
    {
        handsCollider.enabled = true;
    }
    public void WingsOff()
    {
        myAnimator.SetBool("isFlying", false);
        AudioSource.PlayClipAtPoint(wingsPoofSound, mainCam.transform.position, 0.15f);
        PlayWingsExplosion();
        isOtherButtonPressed = false;
        myRigidBody.bodyType = RigidbodyType2D.Dynamic;
        handsCollider.enabled = true;
        myRigidBody.gravityScale = gravity;
        canFly = false;
        wings = false;
        hasPowerUp = false;
        StopCoroutine("WingsCoroutine");
    }
    public bool PlayerHasPowerUp()
    {
        return hasPowerUp;
    }

    IEnumerator WingsCoroutine()
    {
        while (true)
        {
            scoreSystem.AddToScore(10);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
