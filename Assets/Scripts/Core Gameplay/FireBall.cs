using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class FireBall : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private ParticleSystem explosionVFX;
    [SerializeField] private ParticleSystem shieldExplosionVFX;
    [SerializeField] private GameObject feedbackGameObject;
    private MMFeedbacks explosionFeedback;
    private MMFeedbacks squashFeedback;

    private Vector2 screenBounds;
    private Camera mainCam;
    GameSpeed cameraShake;
    Transform myTransform;


    void Awake()
    {
        myTransform = transform;
        mainCam = Camera.main;
        cameraShake = Camera.main.GetComponent<GameSpeed>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        squashFeedback = GetComponentInChildren<MMFeedbacks>();
        squashFeedback.Initialization();
        feedbackGameObject = Instantiate(feedbackGameObject);
        explosionFeedback = feedbackGameObject.GetComponent<MMFeedbacks>();
    }
    private void Start() 
    {
        squashFeedback.PlayFeedbacks();    
    }

    void Update()
    {
        if (myTransform.position.y > screenBounds.y + 1)
        {
            Destroy(feedbackGameObject);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayExplosionEffect();
            AudioSource.PlayClipAtPoint(explosionSound, mainCam.transform.position, 0.2f);
            ShakeCamera();
            explosionFeedback?.PlayFeedbacks();
            Destroy(this.gameObject);
        }
        else if(other.tag == "Shield")
        {
            if(other.gameObject.GetComponent<Shield>().GetDurability() < 1)
            {
                PlayShieldExplosionEffect();
            }
            ShakeCamera();
            Destroy(this.gameObject);
        }
    }

    void PlayExplosionEffect()
    {
        if(explosionVFX != null)
        {
            ParticleSystem instance = Instantiate(explosionVFX, myTransform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration);
        }
    }
    void PlayShieldExplosionEffect()
    {
        if (shieldExplosionVFX != null)
        {
            ParticleSystem instance = Instantiate(shieldExplosionVFX, myTransform.position, Quaternion.identity);
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
