using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRunButton : MonoBehaviour {

    GameObject joystick;

    public static bool isAutoRunEnabled;

    private void Start() {
        isAutoRunEnabled = false;
        joystick = GameObject.FindGameObjectWithTag("joystick");
    }

    public void AutoRun() {
        if(isAutoRunEnabled) {
            joystick.SetActive(true);
            isAutoRunEnabled = false;
        }
        else {
            joystick.SetActive(false);
            isAutoRunEnabled = true;
        }
    }
}
