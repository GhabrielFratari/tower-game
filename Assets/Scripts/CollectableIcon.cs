using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableIcon : MonoBehaviour
{
    [SerializeField] private float duration;
    Slider mySlider;
    MenuManager menu;
    Wings wings;
 
    // Start is called before the first frame update
    void Start()
    {
        wings = FindObjectOfType<Wings>();
        menu = FindObjectOfType<MenuManager>();
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
            wings.DestroyWings();
            menu.DestroyWingsIcon();
        }
    }


}
