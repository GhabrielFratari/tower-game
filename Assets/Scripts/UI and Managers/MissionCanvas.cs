using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCanvas : MonoBehaviour
{
    [SerializeField] Toggle[] myToggles;
    private void Awake()
    {
        for(int i = 0; i < myToggles.Length; i++)
        {
            if (SaveManager.Instance.Load().missions[i])
            {
                myToggles[i].isOn = true;
            }
        }

    }
}
