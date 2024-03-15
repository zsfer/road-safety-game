using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : SingletonBehaviour<Player> {
    [SerializeField] GameObject _ragdoll;
    public bool IsDead { get; private set; }

    public void Hit(Vector3 dir, Collider col) {
        IsDead = true;
        var rb = Instantiate(_ragdoll, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        Physics.IgnoreCollision(rb.GetComponent<Collider>(), col);

        var randomDir = Random.insideUnitCircle.normalized;
        var direction = new Vector3(randomDir.x, 1, randomDir.y);
        rb.AddForce(direction * 500);
        gameObject.SetActive(false);
    }
}
