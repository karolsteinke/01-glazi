using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour {

    [SerializeField] private float speed = 0.76f;
    [SerializeField] private float jumpForce = 1.0f;
    private Rigidbody2D _body;
    private Animator _anim;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    //MonoBehaviour.FixedUpdate has the frequency of the physics system (50fps)
    void FixedUpdate() {
        //set 'movement' - a vector of speed
        float velX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(velX, _body.velocity.y);
        _body.velocity = movement;

        //animate and face velX direction
        _anim.SetFloat("velX", Mathf.Abs(velX));
        if (!Mathf.Approximately(velX, 0)) {
            transform.localScale = new Vector3(Mathf.Sign(velX),1,1);
        }
    }

    void Update() {
        //jumping
        if (Input.GetKeyDown(KeyCode.Z)) {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
