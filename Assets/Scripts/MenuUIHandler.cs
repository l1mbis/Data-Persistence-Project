using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour {
	public TMP_InputField inputFieldName;
	public TextMeshProUGUI bestScore;

	public static string name;

	public void Start() {
		string path = Application.persistentDataPath + "/savefile.json";
		if(File.Exists(path)) {
			bestScore.text = DataHandler.Instance.name + " has the best score: " + DataHandler.Instance.maxScore;
		}
	}
	
    public void StartNew() {
	    name = inputFieldName.text;
	    if (name == "")
		    GameObject.Find("EnterName").GetComponent<TextMeshProUGUI>().color = Color.red;
	    else
		    SceneManager.LoadScene(1);
	    }

    public void Exit() { 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
