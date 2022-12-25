using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONsaving : MonoBehaviour
{
    private PlayerData playerData;
    private PlayerData playerData2;

    private string path = "";
    private string persistentPath = "";

    // Start is called before the first frame update
    void Awake()
    {
        //CreatePlayerData();
        SetPaths();
    }
    private void CreatePlayerData()
    {
        playerData = new PlayerData("MainTower", "MainOutfit", 5, 10);
        //playerData = new PlayerData(5, 10);
    }
    

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveData(playerData);

        if (Input.GetKeyDown(KeyCode.L))
            LoadData();
        
    }
    public void SaveData(PlayerData playerData)
    {
        string savePath = persistentPath;
        Debug.Log("Saving Data at " + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
        //string encrypted = Utils.EncryptAES(json);
        //Debug.Log(encrypted);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    public PlayerData LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        //string encrypted = reader.ReadToEnd();
        //string json = Utils.DecryptAES(encrypted);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
        return data;
    }
}
