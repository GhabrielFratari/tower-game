using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    [Header("Game Speed Settings")]
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float speedMultiplier = 0.1f;
    public float gameSpeed;

    [Header("Camera Shake")]
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;
    Transform myTransform;
    private void Awake()
    {
        myTransform = transform;
        initialPosition = transform.position;
    }
    void FixedUpdate()
    {
        IncreaseSpeed();
    }

    void IncreaseSpeed()
    {
        if(Time.timeScale <= maxSpeed)
        {
            Time.timeScale += speedMultiplier;
            gameSpeed = Time.timeScale;
        }
    }

    public void PlayCameraShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while(elapsedTime < shakeDuration)
        {
            myTransform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.unscaledDeltaTime;
            yield return new WaitForEndOfFrame();
        }
        myTransform.position = initialPosition;
    }
}
