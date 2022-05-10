using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Shield : MonoBehaviour
{
    [SerializeField] private AudioClip shieldSound;
    private int durability = 1;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        durability = 1;
        player.ShieldOn();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "FireBall")
        {
            AudioSource.PlayClipAtPoint(shieldSound, Camera.main.transform.position, 2f);
            durability--;
            if (durability < 1)
            {
                FunctionTimer.Create(player.ShieldOff, 0.1f * Time.unscaledDeltaTime);
                Destroy(gameObject);
            }
        }
    }
}
