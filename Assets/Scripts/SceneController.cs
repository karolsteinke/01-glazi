using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float spawnTime = 5.0f;
    [SerializeField] private GameObject enemyPrefab;
    private float _time = 0;
    private GameObject _enemy;
    
    void Start() {
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    void Update() {
        //spawning enemies at timer
        if (_time < spawnTime) {
            _time += Time.deltaTime;
        }
        else {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(3.04f, 1.6f, 0f);
            _time = 0;
        }
    }
}
