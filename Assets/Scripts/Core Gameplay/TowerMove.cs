using System.Collections;
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
    }
}
