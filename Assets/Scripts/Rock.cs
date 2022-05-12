using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int points = 10;
    [SerializeField] private float speed = 170f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    bool canAddPoints = false;
    bool pointsAdded = false;
    
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && canAddPoints && !pointsAdded)
        {
            FindObjectOfType<ScoreSystem>().AddToScore(points);
            pointsAdded = true;
        }
    }

    public void AddPoints()
    {
        canAddPoints = true;
    }

    public void MissPoints()
    {
        canAddPoints = false;
    }
}
