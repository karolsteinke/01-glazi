using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{   
    [SerializeField] private GameObject redSpawnerPrefab;
    [SerializeField] private GameObject blueSpawnerPrefab;
    [SerializeField] private GameObject flagPrefab;
    [SerializeField] private float redSpawnTime = 5.0f;
    [SerializeField] private Vector3[] redSpawnSpots = new Vector3[] {
        new Vector3(2.72f,1.6f,0), 
        new Vector3(-2.72f,1.6f,0)
    };
    private float _time;
    private CallingFlag[] _flags = new CallingFlag[2];
    
    void Start() {
        Physics2D.IgnoreLayerCollision(6, 6); //ignore collisions between mobs
        CreateRedSpawner();
        CreateFlags();
    }

    void Update() {
        //timer for red spawners
        if (_time < redSpawnTime) {
            _time += Time.deltaTime;
        }
        else {
            CreateRedSpawner();
            _time = 0;
        }
    }

    //to be called from CallingFlag script
    public void UpdateFlags(CallingFlag caller) {
        foreach (CallingFlag flag in _flags) {
            if (flag != null) {
                Destroy(caller.gameObject);
            }
        }
    }

    private void CreateFlags() {
        for (int i=0; i<_flags.Length; i++) {
            GameObject flag = Instantiate(flagPrefab) as GameObject;
            flag.transform.position = new Vector3(i,-0.34f,0);
            _flags[i] = flag.GetComponent<CallingFlag>();
        }
    }

    private void CreateRedSpawner() {
        GameObject spawner = Instantiate(redSpawnerPrefab) as GameObject;
        int rndIdx = Random.Range(0, redSpawnSpots.Length);
        spawner.transform.position = redSpawnSpots[rndIdx];
    }
}
