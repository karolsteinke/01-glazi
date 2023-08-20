using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{   
    [SerializeField] private GameObject spawnerPrefab;
    [SerializeField] private GameObject pickupPrefab;
    [SerializeField] private float redSpawnTime = 5.0f;
    private Vector3[] _redSpawnSpots = new Vector3[] {
        new Vector3(2.72f,1.6f,0),
        new Vector3(-2.72f,1.6f,0)
    };
    private Vector3[] _pickupSpots = new Vector3[] {
        new Vector3(1.28f,-0.16f,0),
        new Vector3(1.28f,-1.76f,0),
        new Vector3(-1.28f,-0.16f,0),
        new Vector3(-1.28f,-1.76f,0)
    };
    private float _time;
    private BroadcastingPickup[] _pickups = new BroadcastingPickup[2];
    
    void Start() {
        //ignore collisions between mobs
        Physics2D.IgnoreLayerCollision(6, 6);

        Messenger<BroadcastingPickup>.AddListener(GameEvent.PICKUP_COLLECTED, UpdatePickups);
        
        CreateSpawner(MobSpawner.MobTypes.Red, _redSpawnSpots[0]);
        StartCoroutine(CreatePickups());
    }

    void Update() {
        //timer for red spawners
        if (_time < redSpawnTime) {
            _time += Time.deltaTime;
        }
        else {
            int randIdx = Random.Range(0, _redSpawnSpots.Length);
            CreateSpawner(MobSpawner.MobTypes.Red, _redSpawnSpots[randIdx]);
            _time = 0;
        }
    }

    //creates pickups, positions are random from predefined array
    private IEnumerator CreatePickups() {
        yield return new WaitForSeconds(2.0f);
        int randIdx = -1;
        for (int i=0; i<_pickups.Length; i++) {
            GameObject pickup = Instantiate(pickupPrefab) as GameObject;
            //random position, make sure it's different second time
            int rand;
            do rand = Random.Range(0, _pickupSpots.Length); while (rand == randIdx);
            randIdx = rand;
            pickup.transform.position = _pickupSpots[randIdx];
            _pickups[i] = pickup.GetComponent<BroadcastingPickup>();
        }
    }

    //to be called on GameEvent.PICKUP_COLLECTED
    public void UpdatePickups(BroadcastingPickup broadcaster) {
        foreach (BroadcastingPickup pickup in _pickups) {
            if (pickup != null) {
                //create blue spawner at second pickup (the one which player isn't collecting)
                if (pickup != broadcaster) {
                    CreateSpawner(MobSpawner.MobTypes.Blue, pickup.transform.position);
                }
                //destroy both pickups
                Destroy(pickup.gameObject);
            }
        }
        StartCoroutine(CreatePickups());
    }

    //creates given type of spawner at pos
    private void CreateSpawner(MobSpawner.MobTypes mobType, Vector3 pos) {
        GameObject spawner = Instantiate(spawnerPrefab) as GameObject;
        spawner.GetComponent<MobSpawner>().mobType = mobType;
        spawner.transform.position = pos;
    }
}
