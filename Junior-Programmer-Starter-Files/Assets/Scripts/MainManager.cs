using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    private void Awake()
    {
        if(Instance!= null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData      //class that will store color
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        SaveData inst = new SaveData();
        inst.teamColor = TeamColor;
        string json = JsonUtility.ToJson(inst);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
