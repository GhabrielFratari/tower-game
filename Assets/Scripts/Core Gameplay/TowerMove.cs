﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    [SerializeField] float velocidade = 0.2f;
    [SerializeField] float contadorVelocidade = 0f;
    
    [SerializeField] Vector2 deslocamento;
    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    
    void FixedUpdate()
    {
        deslocamento = new Vector2 (0, Time.time * velocidade);
        rend.material.mainTextureOffset = deslocamento;
        /* contadorVelocidade += 0.00001f;
         if(velocidade < 0.5f){
             velocidade += 0.00001f;
         }
         else if(contadorVelocidade > 0.5f && velocidade < 0.7f){
             velocidade += 0.00001f;
         }*/
    }
}
