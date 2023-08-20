using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastingPickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        //only when player is triggering flag
        if (other.gameObject.GetComponent<PlatformerPlayer>()) {
            Messenger<BroadcastingPickup>.Broadcast(GameEvent.PICKUP_COLLECTED, this);
        }
    }
}
