using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager> {

    public bool IsStarted { get; set; }
    public event Action OnStart;

    public void StartGame() {
        IsStarted = true;
        OnStart?.Invoke();
    }
}

