/*
 * https://answers.unity.com/questions/1323397/how-to-make-an-object-pulse-continuously.html
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPulsing : MonoBehaviour {
    // Grow parameters
    private float approachSpeed = 0.001f;
    private float growthBound = 1.0f;
    private float shrinkBound = 0.9f;
    private float currentRatio = 1;

    // The text object we're trying to manipulate
    private TextMesh text;
    private float originalFontSize;

    // And something to do the manipulating
    private Coroutine routine;
    private bool keepGoing = true;

    // Attach the coroutine
    void Awake() {
        // Find the text  element we want to use
        this.text = this.gameObject.GetComponent<TextMesh>();

        // Then start the routine
        this.routine = StartCoroutine(this.Pulse());
    }

    IEnumerator Pulse() {
        // Run this indefinitely
        while(keepGoing) {
            // Get bigger for a few seconds
            while(this.currentRatio != this.growthBound) {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                // Update our text element
                this.text.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }

            // Shrink for a few seconds
            while(this.currentRatio != this.shrinkBound) {
                // Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                // Update our text element
                this.text.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
