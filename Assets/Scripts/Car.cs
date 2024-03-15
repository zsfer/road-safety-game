using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour {
    [field: SerializeField] public float SpawnChance { get; }
    [SerializeField] float _speed = 10;
    [SerializeField] Vector2Int _potholeSpawnDurationRange = Vector2Int.one;

    Rigidbody _rb;

    void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        StartCoroutine(DoSpawnPothole());
    }

    void FixedUpdate() {
        var vel = transform.forward * _speed;
        vel.y = _rb.velocity.y;
        _rb.velocity = vel;
    }

    IEnumerator DoSpawnPothole() {
        yield return new WaitForSeconds(Random.Range(_potholeSpawnDurationRange.x, _potholeSpawnDurationRange.y));
        // spawn pothole
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Player")) {
            var dir = (other.collider.transform.position - transform.position).normalized;

            var dot = Vector3.Dot(transform.forward, dir);

            if (dot > 0.7f) {
                Player.Instance.Hit(dir, GetComponent<Collider>());
            }
        }
    }
}
