using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarra2 : MonoBehaviour
{
    public static float speed = 500;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -speed * Time.deltaTime);
        if (transform.position.y < -screenBounds.y * 4)
        {
            Destroy(this.gameObject);
        }
    }
}
