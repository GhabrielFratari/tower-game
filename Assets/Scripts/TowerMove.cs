using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMove : MonoBehaviour
{
    public float velocidade;
    public float contadorVelocidade;
    Vector2 deslocamento;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        deslocamento = new Vector2 (0, Time.time * velocidade);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
        contadorVelocidade += 0.0001f;
        if(velocidade < 0.5f){
            velocidade += 0.0001f;
        }
        else if(contadorVelocidade > 0.5f && velocidade < 0.7f){
            velocidade += 0.00001f;
        }
        Debug.Log (velocidade);
    }
}
