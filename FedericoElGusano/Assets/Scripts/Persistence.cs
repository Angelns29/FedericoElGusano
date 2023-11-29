using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Persistence
{
    public static void Save<T>(T objectToParse, string file)
    {
        string infoJson = JsonUtility.ToJson(objectToParse, true);
        string path = Path.Combine(Application.persistentDataPath, file);
        File.WriteAllText(path, infoJson);
        Debug.Log(path);
        Debug.Log(infoJson);

    }

    public static T Load<T>(string file, T objectToParse)
    {
        string path = Path.Combine(Application.persistentDataPath, file);
        string jsonInfo = File.ReadAllText(path);
        objectToParse = JsonUtility.FromJson<T>(jsonInfo);
        return objectToParse;
    }
}
