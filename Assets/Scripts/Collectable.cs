using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float speed = 170f;
    [SerializeField] ParticleSystem collectableVFX;
    [SerializeField] private int coinValue = 1;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    Player player;
    ScoreSystem scoreSystem;

    void Start()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        player = FindObjectOfType<Player>();
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        if (transform.position.y < -screenBounds.y * 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !player.PlayerHasPowerUp() && this.tag != "Coin")
        {
            PlayCollectableVFX();
            Destroy(gameObject);
        }
        else if(other.tag == "Player" && this.tag == "Coin")
        {
            PlayCollectableVFX();
            scoreSystem.AddCoins(coinValue);
            Destroy(gameObject, 0.1f);
        }
    }

    void PlayCollectableVFX()
    {
        if (collectableVFX != null)
        {
            ParticleSystem instance = Instantiate(collectableVFX, transform.position, collectableVFX.transform.rotation);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }
}
