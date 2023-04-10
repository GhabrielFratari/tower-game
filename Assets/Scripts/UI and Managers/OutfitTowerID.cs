using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitTowerID : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private int index;

    public string GetName()
    {
        return name;
    }
    public int GetIndex()
    {
        return index;
    }
}
