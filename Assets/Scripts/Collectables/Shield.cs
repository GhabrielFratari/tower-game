using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Shield : MonoBehaviour
{
    [SerializeField] private AudioClip shieldSound;
    private int durability = 1;
    private int duration;
    Player player;
    MenuManager menuManager;
    Camera mainCam;
    
    private void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
        player = FindObjectOfType<Player>();
        mainCam = Camera.main;
        CheckUpgradeState(SaveManager.Instance.Load().shield);
    }
    void Start()
    {
        
        menuManager.SpawnShieldIcon();
        player.ShieldOn();
    }

    public void DestroyShield()
    {
        FunctionTimer.Create(player.ShieldOff, 0.1f * Time.unscaledDeltaTime);
        menuManager.DestroyShieldIcon();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "FireBall")
        {
            AudioSource.PlayClipAtPoint(shieldSound, mainCam.transform.position, 2f);
            durability--;
            if (durability < 1)
            {
                DestroyShield();
            }
        }
    }

    void CheckUpgradeState(int shield)
    {
        for(int i = 0; i < 4; i++)
        {
            if(shield == i)
            {
                duration = 7 + (i * 3);
                if(shield == 3)
                {
                    durability = 2;
                }
            }
        }
    }

    public int GetDuration()
    {
        return duration;
    }
}
