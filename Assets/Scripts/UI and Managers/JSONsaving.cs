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

    void Awake()
    {
        SetPaths();
    }
    
    
    private void SetPaths()
    {
        //path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    
    public void SaveData(PlayerData playerData)
    {

        Debug.Log("Saving Data at " + persistentPath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        //string encrypted = Utils.EncryptAES(json);
        //Debug.Log(encrypted);

        File.WriteAllText(persistentPath, json);
        //using StreamWriter writer = new StreamWriter(savePath);
        //writer.Write(json);
    }
    public PlayerData LoadData()
    {
        //using StreamReader reader = new StreamReader(persistentPath);
        //string encrypted = reader.ReadToEnd();
        //string json = Utils.DecryptAES(encrypted);
        //string json = reader.ReadToEnd();
        string json = File.ReadAllText(persistentPath);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
        return data;
    }
}
