using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;

    // --- Pause ---
    public void Pause() {
        if(!GC.isPaused) {
            GC.isPaused = true;
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }
    }

    // --- Resume ---
    public void Resume() {
        if(GC.isPaused) {
            GC.isPaused = false;
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
        }
    }

    // --- Options ---

    // --- Quit ---
    
}
