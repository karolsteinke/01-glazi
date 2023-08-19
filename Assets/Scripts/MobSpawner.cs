using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTime = 3.0f;
    [SerializeField] private GameObject mobPrefab;
    private GameObject _mob;

    void Start() {
        StartCoroutine(SpawnAndDie());
    }

    private IEnumerator SpawnAndDie() {
        yield return new WaitForSeconds(spawnTime);
        _mob = Instantiate(mobPrefab) as GameObject;
        _mob.transform.position = transform.position;
        Destroy(gameObject);
    }

}
