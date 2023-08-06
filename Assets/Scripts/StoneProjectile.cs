using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneProjectile : MonoBehaviour
{
    public bool fired {get; private set;}
    private Rigidbody2D _body;
    private BoxCollider2D _box;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        fired = false;
    }

    public void Fire(Vector3 direction) {
        _body.constraints = RigidbodyConstraints2D.None;
        _box.usedByEffector = false;
        _box.isTrigger = true;
        _body.AddForce(direction, ForceMode2D.Impulse);
        fired = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
	}
}
