using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;

public class Save_con : MonoBehaviour
{
    public  Save_data data;
    public Audio_UI audi;
    public Sub_Ui sub;
    string dataFilePath;
    BinaryFormatter bf;

    void Awake()
    {
        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/Game.dat";
        Debug.Log(dataFilePath);
    }

    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadData()
    {
        if (File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (Save_data)bf.Deserialize(fs);
            fs.Close();
        }
    }

    private void OnEnable()
    {
        LoadData();
        audi.volume_load();
        sub.load_Sub();
    }

    private void OnDisable()
    {
        SaveData();
    }
}
