using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
    // --- Variables & Objects ---
    public GameObject destructionPoint;

    // --- Start ---
    void Start () {
        destructionPoint = GameObject.Find("DestructionPoint");
	}

    // --- Main Loop ---
    void Update () {
		if(transform.position.x < destructionPoint.transform.position.x) {
            gameObject.SetActive(false);
        }
	}
}
