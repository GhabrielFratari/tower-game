using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HandlePostProcessing : MonoBehaviour
{
    [SerializeField] LayerMask postProcessingLayerMask;
    private void Awake() 
    {
        if(GameManager.GetPostProcessing() == 0)
        {
            GetComponent<PostProcessLayer>().volumeLayer = postProcessingLayerMask;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
