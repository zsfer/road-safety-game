using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnPoint : MonoBehaviour {
    [field: SerializeField] public Transform TargetPoint { get; }
    Queue<GameObject> _carPool;
}
