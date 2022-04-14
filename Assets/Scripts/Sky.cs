using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    Material material;
    Vector2 deslocamento;
    public float  velocidadeX, velocidadeY;
    
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        deslocamento = new Vector2(velocidadeX, velocidadeY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        material.mainTextureOffset += deslocamento * Time.unscaledDeltaTime;
    }
}
