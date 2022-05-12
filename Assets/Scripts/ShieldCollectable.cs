using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectable : MonoBehaviour
{
    [SerializeField] private float speed = 170f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    void Start()
    {
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
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
