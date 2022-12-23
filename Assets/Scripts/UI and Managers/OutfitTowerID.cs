using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitTowerID : MonoBehaviour
{
    [SerializeField] private string name;

    public string GetName()
    {
        return name;
    }
}
