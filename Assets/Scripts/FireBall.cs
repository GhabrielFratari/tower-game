using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private ParticleSystem explosionVFX;

    private Vector2 screenBounds;
    GameSpeed cameraShake;


    void Start()
    {
        cameraShake = Camera.main.GetComponent<GameSpeed>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (transform.position.y > screenBounds.y * 2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayExplosionEffect();
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.2f);
            ShakeCamera();
            Destroy(this.gameObject);
        }
    }

    void PlayExplosionEffect()
    {
        if(explosionVFX != null)
        {
            ParticleSystem instance = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null)
        {
            cameraShake.PlayCameraShake();
        }
    }
}
