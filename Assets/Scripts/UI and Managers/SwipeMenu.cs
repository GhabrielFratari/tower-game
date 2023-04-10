using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;
    string towerID;
    string outfitID;
    SelectButton selectButton;  

    void Start()
    {
        selectButton = FindObjectOfType<SelectButton>();
    }

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for(int i = 0; i< pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i = 0; i < pos.Length; i++)
            {
                if(scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                GameObject instance = transform.GetChild(i).gameObject;
                instance.transform.localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                instance.gameObject.GetComponent<Button>().interactable = true;
                if (gameObject.tag == "Outfit")
                {
                    selectButton.OnOutfitSelect(instance.gameObject.GetComponent<OutfitTowerID>().GetIndex());
                    outfitID = instance.gameObject.GetComponent<OutfitTowerID>().GetName();
                    //Debug.Log(outfitID);
                }
                else if (gameObject.tag == "Tower")
                {
                    selectButton.OnTowerSelect(instance.gameObject.GetComponent<OutfitTowerID>().GetIndex());
                    towerID = instance.gameObject.GetComponent<OutfitTowerID>().GetName();
                    //Debug.Log(towerID);

                }

                for (int a = 0; a < pos.Length; a++)
                {
                    if(a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        transform.GetChild(a).gameObject.GetComponent<Button>().interactable = false;
                    }
                }
            }
        }
    }

    public string GetTowerID()
    {
        return towerID;
    }
    public string GetOutfitID()
    {
        return outfitID;
    }
}
