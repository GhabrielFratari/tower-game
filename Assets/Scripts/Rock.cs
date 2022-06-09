using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] int points = 10;
    [SerializeField] private float speed = 170f;
    ScoreSystem scoreSystem;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    bool canAddPoints = false;
    bool pointsAdded = false;
    Transform myTransform;
    
    void Awake()
    {
        myTransform = transform;
        scoreSystem = FindObjectOfType<ScoreSystem>();
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        if (myTransform.position.y < -screenBounds.y - 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && canAddPoints && !pointsAdded)
        {
            scoreSystem.AddToScore(points);
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
