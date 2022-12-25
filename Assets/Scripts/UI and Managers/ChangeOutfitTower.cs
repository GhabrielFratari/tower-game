using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChangeOutfitTower : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] Towers[] towers;
    [SerializeField] Outfits[] outfits;
    JSONsaving jsonSaving;

    [System.Serializable]
    public struct Towers
    {
        public string towerName;
        public GameObject prefab;
    }
    [System.Serializable]
    public struct Outfits
    {
        public string outfitName;
        public RuntimeAnimatorController outfit;
    }
    private void Awake()
    {
        jsonSaving = FindObjectOfType<JSONsaving>();
       
    }
    private void Start()
    {
        ChangeTower();
        ChangeOutfit();
    }
    private void ChangeTower()
    {
        //string name = Get tower name from file
        string name = jsonSaving.LoadData().towerID;
        if (name == null || name == "") name = "MainTower";

        for(int i = 0; i < towers.Length; i++)
        {
            if(towers[i].towerName == name)
            {
                Instantiate(towers[i].prefab, towers[i].prefab.transform.position, Quaternion.identity);
            }
        }
        
    }
    private void ChangeOutfit()
    {
        //string name = Get outfit name from file
        string name = jsonSaving.LoadData().outfitID;
        if(name == null || name == "") name = "MainOutfit";

        for (int i = 0; i < outfits.Length; i++)
        {
            if (outfits[i].outfitName == name)
            {
                player.GetComponent<Animator>().runtimeAnimatorController = outfits[i].outfit;
            }
        }

    }
}
