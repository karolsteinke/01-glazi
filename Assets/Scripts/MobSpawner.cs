using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public enum MobTypes {
        Green = 0,
        Blue = 1
    }
    public MobTypes mobType = MobTypes.Green;
    [SerializeField] private float spawnTime = 1.5f;
    [SerializeField] private GameObject[] mobPrefabs = new GameObject[2];
    private GameObject _mob;

    void Start() {
        StartCoroutine(SpawnAndDie());
    }

    private IEnumerator SpawnAndDie() {
        yield return new WaitForSeconds(spawnTime);
        _mob = Instantiate(mobPrefabs[(int)mobType]) as GameObject;
        _mob.transform.position = transform.position;
        Destroy(gameObject);
    }

}
