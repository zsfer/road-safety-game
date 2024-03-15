using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance { get; private set; }

    protected virtual void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            throw new System.Exception($"Instance {Instance.GetInstanceID()} already exists");
        } else
            Instance = GetComponent<T>();

        PostAwake();
    }

    protected virtual void PostAwake() {

    }
}
