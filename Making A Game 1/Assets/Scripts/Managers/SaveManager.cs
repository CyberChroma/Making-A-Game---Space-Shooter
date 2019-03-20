using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    [HideInInspector] public int unlockedLevel = 1;
    [HideInInspector] public int level;

    private static SaveManager instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void New ()
    {
        unlockedLevel = 1;
        Save();
    }

    public void Load ()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            unlockedLevel = data.unlockedLevel;
        } else
        {
            Save();
        }
    }

    public void Save ()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        SaveData data = new SaveData();
        data.unlockedLevel = unlockedLevel;
        bf.Serialize(file, data);
        file.Close();
    }
}

[System.Serializable]
public class SaveData
{
    public int unlockedLevel;
}
