using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsSpawner : MonoBehaviour {
    [SerializeField] GameObject[] _carPrefabs;

    void Start() {
        GameManager.Instance.OnStart += StartSpawning;
    }

    private void StartSpawning() {

    }

    void Update() {

    }
}
