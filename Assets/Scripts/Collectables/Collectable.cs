using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float speed = 170f;
    [SerializeField] ParticleSystem collectableVFX;
    [SerializeField] private int coinValue = 1;
    [SerializeField] private float raySize = 3f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    Player player;
    ScoreSystem scoreSystem;
    Transform myTransform;
    private int bitMask;
    private bool attracted = false;
    private bool coinAdded = false;
    private Vector3 attractorTarget;
    private float attractorSpeed;
    

    void Awake()
    {
        myTransform = transform;
        scoreSystem = FindObjectOfType<ScoreSystem>();
        player = FindObjectOfType<Player>();
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bitMask = 1 << 10;
    }
    private void Start()
    {
        //Debug.DrawRay(myTransform.position, myTransform.TransformDirection(Vector2.down) * raySize, Color.red, 5f);
        RaycastHit2D hitDown = Physics2D.Raycast(myTransform.position, myTransform.TransformDirection(Vector2.down), raySize, bitMask);
        if (hitDown.collider != null)
        {
            //Debug.Log("Hit something: " + hitDown.collider.name);
            myTransform.position = new Vector2(myTransform.position.x, hitDown.collider.gameObject.transform.position.y + 1.35f);
            //1.35 is the distance between 2 rocks, divided by 2
        }
        else
        {
            RaycastHit2D hitUp = Physics2D.Raycast(myTransform.position, myTransform.TransformDirection(Vector2.up), raySize, bitMask);
            if(hitUp.collider != null)
            {
                //Debug.Log("Hit something: " + hitUp.collider.name);
                myTransform.position = new Vector2(myTransform.position.x, hitUp.collider.gameObject.transform.position.y - 1.35f);
                //1.35 is the distance between 2 rocks, divided by 2
            }
        }

    }
    void FixedUpdate()
    {
        if(!attracted)
        {
            rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, attractorTarget, attractorSpeed * Time.deltaTime);
            if(transform.position == attractorTarget)
            {
                if (collectableVFX != null)
                {
                    ParticleSystem instance = Instantiate(collectableVFX, myTransform.position, collectableVFX.transform.rotation);
                    Destroy(instance.gameObject, instance.main.duration);
                }
            }
        }
        
        if (myTransform.position.y < -screenBounds.y * 3)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetAttractorCollider(Vector3 attractorTarget, float attractorSpeed)
    {
        this.attractorTarget = attractorTarget;
        this.attractorSpeed = attractorSpeed;
        attracted = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.tag == "Player" && !player.PlayerHasPowerUp() && this.tag != "Coin")
        {
            PlayCollectableVFX();
            Destroy(gameObject);
        }*/
        if((other.tag == "Player" || other.tag == "Shield") && this.CompareTag("Coin") && !coinAdded)
        {
            coinAdded = true;

            scoreSystem.AddCoins(coinValue);
            SaveManager.Instance.AddCoins(coinValue);
            Destroy(gameObject, 0.3f);
        }
    }

    public void PlayCollectableVFX()
    {
        if (collectableVFX != null)
        {
            ParticleSystem instance = Instantiate(collectableVFX, myTransform.position, collectableVFX.transform.rotation);
            Destroy(instance.gameObject, instance.main.duration);
        }
        Destroy(gameObject);
    }
    
}
