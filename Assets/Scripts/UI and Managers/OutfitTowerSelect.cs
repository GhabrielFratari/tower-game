using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitTowerSelect : MonoBehaviour
{
    SwipeMenu swipeMenu;
    [SerializeField] private Animator animatorOutfit;
    private void Awake()
    {
        swipeMenu = FindObjectOfType<SwipeMenu>();
    }


    public void SelectOutfit()
    {
        
    }
}
