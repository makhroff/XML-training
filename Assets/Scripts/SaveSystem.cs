using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/cube.cubedata";
    public static void SaveCube(this CubeMovement cube)
    {
        BinaryFormatter formatter = new();
        
        FileStream stream = new(path, FileMode.OpenOrCreate);

        CubeData data = new(cube);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CubeData LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(path, FileMode.Open);

            CubeData data = formatter.Deserialize(stream) as CubeData;

            stream.Close(); 

            return data; 
        }
        else
        {
            throw new NullReferenceException("No correct path found");
        }
    }
}
