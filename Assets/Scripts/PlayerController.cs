using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    [SerializeField] float _moveSpeed = 7;
    [SerializeField] float _rotationSpeed = 10;

    CharacterController _cc;
    Vector3 _vel;
    Vector2 _input;

    #region Input stuff
    GameInputActions _actions;
    InputAction _moveAction;
    InputAction _interactAction;
    #endregion

    private void Awake() {
        _actions = new();
    }

    private void OnEnable() {
        _moveAction = _actions.Player.Move;
        _moveAction.Enable();
        _interactAction = _actions.Player.Interact;
        _interactAction.Enable();
    }

    private void OnDisable() {
        _moveAction.Disable();
        _interactAction.Disable();
    }

    void Start() {
        _cc = GetComponent<CharacterController>();
    }

    void Update() {
        _input = _moveAction.ReadValue<Vector2>();
        _vel = (Vector3.right * _input.x + Vector3.forward * _input.y).normalized * _moveSpeed;

        _cc.SimpleMove(_vel);

        // rotatiom
        if (_vel.magnitude > 0)
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(_vel), _rotationSpeed * Time.deltaTime);
    }

}
