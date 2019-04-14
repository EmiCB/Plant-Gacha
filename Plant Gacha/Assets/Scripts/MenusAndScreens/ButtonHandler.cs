using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {
    // --- Variables & Objects ---
    public GameObject buttonPrefab;
    public RectTransform parentPanel;

    private string[] _locations = new string[] {"Experimental", "Prairie", "Desert", "Jungle", "Forest"};
    private int _numOfButtons;

    // --- Start ---
    void Start() {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        buttonPrefab = GameObject.Find("ButtonPrefab");

        if(sceneName == "HomeScreen") 
            HomeScreen();
        

        Destroy(buttonPrefab);
	}

	// --- Home Screen Button Generation ---
	void HomeScreen() {
        _numOfButtons = _locations.Length;
        for (int i = 0; i < _numOfButtons; i++) {
            GameObject newButton = (GameObject)Instantiate(buttonPrefab);
            newButton.transform.SetParent(parentPanel, false);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.GetComponentInChildren<Text>().text = _locations[i];
        }
    }
}
