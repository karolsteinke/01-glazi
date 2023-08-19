using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallingFlag : MonoBehaviour
{
    [SerializeField] private SceneController controller;

    void OnTriggerEnter2D(Collider2D other) {
        //only when player is triggering flag
        if (other.gameObject.GetComponent<PlatformerPlayer>()) {
            controller.UpdateFlags(this);
        }
    }
}
