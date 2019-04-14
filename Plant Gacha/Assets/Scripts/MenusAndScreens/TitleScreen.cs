using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
    // --- Main Loop ---
	void Update () {
        //takes user to home screen when tapped
		if(Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("HomeScreen");
        }
	}
}
