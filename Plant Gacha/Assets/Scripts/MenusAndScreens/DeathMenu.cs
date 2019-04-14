using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenu;

    // --- Restart ---
    public void Restart()
    {
        if (GC.isPaused)
        {
            GC.isPaused = false;
            Time.timeScale = 1.0f;
            deathMenu.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // --- Options ---

    // --- Quit ---

}
