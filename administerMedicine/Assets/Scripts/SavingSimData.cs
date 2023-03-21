using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SavingSimData
{
    public static string directory = "/SaveData/";
    public static string fileName = "SimSaveData.txt";

    public static void SaveData(SaveObject SO)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(SO);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveObject LoadData()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject SO = new SaveObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            SO = JsonUtility.FromJson<SaveObject>(json);
        } else
        {
            Debug.Log("Save file does not exist");
        }

        return SO;
    }
}
