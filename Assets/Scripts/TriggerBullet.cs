using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;
    private SpriteRenderer _sprite;
    private SpriteRenderer _tailSprite;
    private Color _startColor;

    void Start() {
        _sprite = GetComponent<SpriteRenderer>();
        _tailSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _startColor = _sprite.color;
        StartCoroutine(Blink());
    }

    void FixedUpdate() {
        //move in facing direction
        transform.Translate(_speed*transform.localScale.x, 0, 0);
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        //broadcast on player hit or destroy on wall hit
        if (col.GetComponent<PlatformerPlayer>()) {
            Messenger.Broadcast(GameEvent.PLAYER_HIT);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Map Elements")) {
            Destroy(gameObject);
        }
	}

    private IEnumerator Blink() {
        while (true) {
            _sprite.color = _startColor;
            _tailSprite.color = _startColor;
            yield return new WaitForSeconds(.3f);
            _sprite.color = Color.white;
            _tailSprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }
}
