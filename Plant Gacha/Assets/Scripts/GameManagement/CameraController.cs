using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // --- Variables & Objects ---
    public PlayerController player;

    private Vector3 _lastPlayerPos;

    private float _distToMoveX;
    private float _distToMoveY;

    // --- Start ---
    void Start() {
        player = FindObjectOfType<PlayerController>();
        _lastPlayerPos = player.transform.position;
    }

    // --- Main Loop ---
    void Update() {
        _distToMoveX = player.transform.position.x - _lastPlayerPos.x;
        _distToMoveY = player.transform.position.y - _lastPlayerPos.y;
        transform.position = new Vector3(transform.position.x + _distToMoveX, transform.position.y + (_distToMoveY / 2), transform.position.z);
        _lastPlayerPos = player.transform.position;
    }
}
