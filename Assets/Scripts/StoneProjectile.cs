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

    
    void FixedUpdate() {
        //destroy if outside the scene
        var posX = transform.position.x;
        if (posX > 3.2f || posX < -3.2f) {
            Destroy(this.gameObject);
        }
    }

    public void Fire(Vector3 direction) {
        _body.constraints = RigidbodyConstraints2D.None;
        _body.constraints = RigidbodyConstraints2D.FreezeRotation;
        _box.usedByEffector = false;
        //_box.isTrigger = true;
        _body.AddForce(direction, ForceMode2D.Impulse);
        fired = true;
    }

    /*
    void OnTriggerEnter2D(Collider2D other) {
        ReactiveTarget target = other.gameObject.GetComponent<ReactiveTarget>();
        if (target != null) {
            target.ReactToHit();
        }
        
        Destroy(this.gameObject);
	}
    */

    /*
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("col");
    }
    */
}
