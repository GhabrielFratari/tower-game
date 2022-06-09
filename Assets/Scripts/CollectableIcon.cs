using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableIcon : MonoBehaviour
{
    [SerializeField] private float duration;
    Slider mySlider;
    Wings wingsObj;
    Shield shieldObj;
    [SerializeField] bool wings, shield;
 
    // Start is called before the first frame update
    void Awake()
    {
        if (wings)
        {
            wingsObj = FindObjectOfType<Wings>();

        }
        else if (shield)
        {
            shieldObj = FindObjectOfType<Shield>();
        }
        mySlider = GetComponentInChildren<Slider>();
        mySlider.maxValue = duration;
        mySlider.value = mySlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseSlider();
    }

    void DecreaseSlider()
    {
        mySlider.value -= Time.unscaledDeltaTime;

        if(mySlider.value == 0)
        {
            if (wings)
            {
                wingsObj.DestroyWings();
            }
            else if (shield)
            {
                shieldObj.DestroyShield();
            }
            
        }
    }


}
