using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    private int _score = 0;

    void Start()
    {
        Messenger<BroadcastingPickup>.AddListener(GameEvent.PICKUP_COLLECTED, OnPickupCollected);
    }

    void OnDestroy() {
        Messenger<BroadcastingPickup>.RemoveListener(GameEvent.PICKUP_COLLECTED, OnPickupCollected);
    }

    private void OnPickupCollected(BroadcastingPickup broadcaster) {
        _score++;
        scoreLabel.text = "" + _score;
        if (!scoreLabel.gameObject.activeSelf) {
            scoreLabel.gameObject.SetActive(true);
        }
    }
}
