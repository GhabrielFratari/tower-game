using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableIcon : MonoBehaviour
{
    private float duration;
    Slider mySlider;
    Wings wingsObj;
    Shield shieldObj;
    private bool hasPlayed = false;
    [SerializeField] bool wings, shield;
 
    // Start is called before the first frame update
    void Awake()
    {
        if (wings)
        {
            wingsObj = FindObjectOfType<Wings>();
            duration = wingsObj.GetDuration();

        }
        else if (shield)
        {
            shieldObj = FindObjectOfType<Shield>();
            duration = shieldObj.GetDuration();
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
        if(Time.timeScale != 0f)
        {
            mySlider.value -= Time.unscaledDeltaTime;
            if (mySlider.value < 1.5f && !hasPlayed)
            {
                hasPlayed = true;
                if (wings)
                {
                    wingsObj.PlayFlashFeedback();
                }
                else if (shield)
                {
                    shieldObj.PlayFlashFeedback();
                }
            }

            if (mySlider.value == 0)
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


}
