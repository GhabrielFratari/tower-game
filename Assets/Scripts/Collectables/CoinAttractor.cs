using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAttractor : MonoBehaviour
{
    [SerializeField] private float attractorSpeed = 5f;
    private Collectable coin;

    private void Awake() 
    {
        coin = GetComponentInParent<Collectable>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Vector3 colliderCenter = new Vector3(other.bounds.center.x, other.bounds.center.y, other.bounds.center.z);
            coin.SetAttractorCollider(colliderCenter, attractorSpeed);
        }    
    }
    
}
