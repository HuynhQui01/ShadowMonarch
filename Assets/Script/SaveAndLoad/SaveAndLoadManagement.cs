using UnityEngine;
using System.IO;

public static class SaveLoadManager
{
    public static void SaveGame(GameData data)
    {
        string path = Application.persistentDataPath + "/gameData.json";
         Debug.Log("Saving game data to: " + path);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
