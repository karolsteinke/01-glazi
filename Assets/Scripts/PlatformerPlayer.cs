using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour {

    public float speed = 850.0f;
    private Rigidbody2D _body;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        //set 'movement' - a vector of speed
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
        /*
        if (Time.deltaTime > 0.008f) {
            Debug.Log(Time.deltaTime);
        }
        */
        /*
        if (movement.sqrMagnitude > 8.0f) {
            Debug.Log("Time.deltaTime:" + Time.deltaTime);
        }
        */
    }
}
