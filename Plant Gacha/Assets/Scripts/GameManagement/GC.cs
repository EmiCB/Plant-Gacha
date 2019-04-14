using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GC : MonoBehaviour {
    // --- Variables & Objects ---
    public TextMesh seedText;
    public TextMesh rareSeedText;

    public static bool isPaused = false;

    public int totalSeeds = 0;
    public int totalRareSeeds = 0;
    
    // --- Start ---
	void Start () {
        loadCurrency();
	}
	
    // --- Main Loop ---
	void Update () {
        saveCurrency();
        UpdateTexts();
	}

    // --- Currency ---
    void saveCurrency() {
        PlayerPrefs.SetInt("Total Seeds", totalSeeds);
        PlayerPrefs.SetInt("Total Rare Seeds", totalRareSeeds);
    }
    void loadCurrency() {
        totalSeeds = PlayerPrefs.GetInt("Total Seeds");
        totalRareSeeds = PlayerPrefs.GetInt("Total Rare Seeds");
    }

    // --- Text ---
    void UpdateTexts()
    {
        seedText.text = "Seeds: " + totalSeeds;
        rareSeedText.text = "Rare Seeds: " + totalRareSeeds;
    }
}
