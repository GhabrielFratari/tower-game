using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] Color blue;
    TextMeshProUGUI text;
    JSONsaving jsonSaving;
    

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        jsonSaving = FindObjectOfType<JSONsaving>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (tag == "Outfit")
        {
            if (FindObjectOfType<SwipeMenu>().GetOutfitID() == jsonSaving.LoadData().outfitID)
            {
                text.text = "Selected";
                gameObject.GetComponent<Image>().color = blue;
            }
            else
            {
                text.text = "Select";
                gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        else if (tag == "Tower")
        {
            if (FindObjectOfType<SwipeMenu>().GetTowerID() == jsonSaving.LoadData().towerID)
            {
                text.text = "Selected";
                gameObject.GetComponent<Image>().color = blue;
            }
            else
            {
                text.text = "Select";
                gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        
    }
}
