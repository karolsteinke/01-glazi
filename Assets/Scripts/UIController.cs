using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private GameObject EndMessage;
    private int _score = 0;

    void Start()
    {
        Messenger<BroadcastingPickup>.AddListener(GameEvent.PICKUP_COLLECTED, OnPickupCollected);
        Messenger.AddListener(GameEvent.ENEMY_ESCAPED, OnEnemyEscaped);
        Messenger.AddListener(GameEvent.PLAYER_HIT, ShowEndMessage);
    }

    void OnDestroy() {
        Messenger<BroadcastingPickup>.RemoveListener(GameEvent.PICKUP_COLLECTED, OnPickupCollected);
        Messenger.RemoveListener(GameEvent.ENEMY_ESCAPED, OnEnemyEscaped);
        Messenger.RemoveListener(GameEvent.PLAYER_HIT, ShowEndMessage);
    }

    private void OnPickupCollected(BroadcastingPickup broadcaster) {
        _score++;
        scoreLabel.text = "" + _score;
        if (!scoreLabel.gameObject.activeSelf) {
            scoreLabel.gameObject.SetActive(true);
        }
    }

    private void OnEnemyEscaped() {
        _score--;
        scoreLabel.text = "" + _score;
    }

    private void ShowEndMessage() {
        EndMessage.SetActive(true);
    }
}
