using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour {
    
    [SerializeField] private float speed = 0.90f;
    [SerializeField] private float jumpForce = 2.2f;
    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    private bool _grounded = false;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
    }

    //MonoBehaviour.FixedUpdate has the frequency of the physics system (50fps)
    void FixedUpdate() {
        //set 'movement' - a vector of speed
        float velX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(velX, _body.velocity.y);
        _body.velocity = movement;

        //set animator's parameter
        _anim.SetFloat("velX", Mathf.Abs(velX));

        //face sprite to velocity
        if (!Mathf.Approximately(velX, 0)) {
            transform.localScale = new Vector3(Mathf.Sign(velX),1,1);
        }

        //turn off gravity when grounded
        if ((_grounded && velX == 0) && _body.velocity.y <= 0) {
            _body.gravityScale = 0;
        }
        else {
            _body.gravityScale = 1;
        }
    }

    void Update() {
        //detect if grounded
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y-.021f);
        Vector2 corner2 = new Vector2(min.x, min.y-.040f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        _grounded = hit != null;
        /*
        //DEBUG DRAW LINE
        UnityEngine.Debug.DrawLine(corner1, corner2,  Color.red);
        */

        //jumping
        if (_grounded && Input.GetKeyDown(KeyCode.Z)) {
            Vector2 vel = _body.velocity;
            _body.velocity = new Vector2(vel.x, 0);
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.GetComponent<WanderingAI>()) {
            Messenger.Broadcast(GameEvent.PLAYER_HIT);
        }
    }
}
