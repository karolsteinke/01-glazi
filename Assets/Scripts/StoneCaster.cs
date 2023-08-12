using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCaster : MonoBehaviour
{
    [SerializeField] private float firePower = 3.0f;
    [SerializeField] private GameObject stonePrefab;
    private Transform _crosshair;
    private StoneProjectile _stone;

    void Start() {
        _crosshair = transform.GetChild(0).GetComponent<Transform>();
    }

    //MonoBehaviour.FixedUpdate has the frequency of the physics system (50fps)
    void FixedUpdate() {
        //turn off crosshair when stone has been casted
        if (_stone) {
            _crosshair.gameObject.SetActive(false);
            
            //DEBUG DRAW CROSSHAIR LINE
            if (!_stone.fired) {
                Vector3 stonePos = _stone.gameObject.transform.position;
                Vector3 heading = stonePos - transform.position;
                Vector3 direction = heading / heading.magnitude;
                UnityEngine.Debug.DrawLine(stonePos, stonePos + direction / 3,  Color.red);
            }
        }
        else {
            _crosshair.gameObject.SetActive(true);
        }
    }

    void Update() {
        //casting stone and firing stone
        if (Input.GetKeyDown(KeyCode.X)) {
            if ((_stone == null)) {
                if (_crosshair.gameObject.activeSelf) {
                    _stone = Instantiate(stonePrefab, _crosshair.position, _crosshair.rotation).GetComponent<StoneProjectile>();
                }
            }
            else {
                if (!_stone.fired) {
                    Vector3 heading = _stone.gameObject.transform.position - transform.position;
                    Vector3 direction = heading / heading.magnitude;
                    _stone.Fire(direction * firePower);
                }
            }
        }
    }
}
