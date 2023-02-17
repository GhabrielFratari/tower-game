using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    Material material;
    [SerializeField] Material blackSky;
    MeshRenderer meshRend;
    Vector2 deslocamento;
    public float  velocidadeX, velocidadeY;
    
    private void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SaveManager.Instance.Load().currentOutfit == "Astronaut")
        {
            meshRend.material = blackSky;
        }
        material = GetComponent<Renderer>().material;
        deslocamento = new Vector2(velocidadeX, velocidadeY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        material.mainTextureOffset += deslocamento * Time.unscaledDeltaTime;
    }
}
