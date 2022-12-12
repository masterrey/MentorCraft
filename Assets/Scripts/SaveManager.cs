using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static void Save(Map map)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
        Debug.Log(Application.persistentDataPath);
        bf.Serialize(file, map);
        file.Close();

    }
}
