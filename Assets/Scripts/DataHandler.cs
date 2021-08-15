using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour {
	public static DataHandler Instance;

    public int maxScore;
    public string name;
	
    private void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            LoadUser();
	}
    
    [System.Serializable]
        class SaveData {
            public string name;
            public int maxScore;
        }
        
        public void SaveUser() {
            SaveData data = new SaveData();
            data.name = name;
            data.maxScore = maxScore;
    
            string json = JsonUtility.ToJson(data);
            
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    
        public void LoadUser() {
            string path = Application.persistentDataPath + "/savefile.json";
    
            if (File.Exists(path)) {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                
                name = data.name;
                maxScore = data.maxScore;
            }
        }
}
