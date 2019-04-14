using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
    // --- Variables & Objects ---
    public GameObject platform;

    public Transform generationPoint;
    public Transform maxHeightPoint;

    public ObjectPooler[] platformPools;

    private int _selectedPlatform;
    private float _distanceBetween;
    private float _distanceBetweenMin;
    private float _distanceBetweenMax;

    private float _platformWidth;
    private float[] _platformWidths;

    private float _minHeight;
    private float _maxHeight;
    private float _maxHeightChange;
    private float _heightChange;
    
    // --- Start ---
    void Start () {
        //calculate widths of platforms
        _platformWidths = new float[platformPools.Length];
        for(int i = 0; i < _platformWidths.Length; i++) {
            _platformWidths[i] = platformPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        //set distances between
        _distanceBetweenMin = 1.0f;
        _distanceBetweenMax = 5.0f;

        //set heights
        _minHeight = transform.position.y;
        _maxHeight = maxHeightPoint.position.y;
        _maxHeightChange = 3.0f;
	}
	
	// --- Main Loop ---
	void Update () {
		GeneratePlatforms();
	}

    // --- Platfrom Generator ---
    void GeneratePlatforms()
    {
        if (transform.position.x < generationPoint.transform.position.x)
        {
            //set random distance
            _distanceBetween = Random.Range(_distanceBetweenMin, _distanceBetweenMax);
            //choose random platform size
            _selectedPlatform = Random.Range(0, platformPools.Length);
            //calculate height
            _heightChange = transform.position.y + Random.Range(_maxHeightChange, -_maxHeightChange);
            //constrain the height change
            if (_heightChange > _maxHeight)
                _heightChange = _maxHeight;
            else if (_heightChange < _minHeight)
                _heightChange = _minHeight;
            //move generation point ahead
            transform.position = new Vector3(transform.position.x + (_platformWidths[_selectedPlatform] / 2) + _distanceBetween, _heightChange, transform.position.z);
            //move last platform to front
            GameObject newPlatform = platformPools[_selectedPlatform].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            //move generation point ahead
            transform.position = new Vector3(transform.position.x + (_platformWidths[_selectedPlatform] / 2), transform.position.y, transform.position.z);
        }
    }
}
