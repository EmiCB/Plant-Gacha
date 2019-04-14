using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAndTestingControls : MonoBehaviour {
    //options
    public bool flatGround;

    //other things
    public GameObject platformGenTool;
    public GameObject[] platformGenTools;

	void Start () {
        AddPlatformGenTools();

        if (flatGround)
        {
            DisablePlatformGeneration();
            //EnableFlatFloor();
        }
    }
	
	void Update () {
		
	}


    void AddPlatformGenTools() {
        if(platformGenTools == null) {
            platformGenTools = GameObject.FindGameObjectsWithTag("platformGeneration");
        }
    }
    void DisablePlatformGeneration() {
        //turn off platform generation
        foreach(GameObject platformGenTool in platformGenTools) {
            platformGenTool.SetActive(false);
        }
    }
    void EnableFlatFloor() {
        //create a continuous flat floor
    }
}
