using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarra : MonoBehaviour
{
    public float velocidade;
    public float contadorVelocidade;
    private Rigidbody2D rb;
    //Vector2 deslocamento;
    private Vector2 screenBounds;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, Time.time * -velocidade);
        contadorVelocidade += 0.00001f;
        if (velocidade < 0.5f)
        {
            velocidade += 0.00001f;
        }
        else if (contadorVelocidade > 0.5f && velocidade < 0.7f)
        {
            velocidade += 0.00001f;
        }

        if (transform.position.y < -screenBounds.y * 4)
        {
            Destroy(this.gameObject);
        }
    }
}
