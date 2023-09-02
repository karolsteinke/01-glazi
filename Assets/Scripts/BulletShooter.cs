using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private bool preparing = false;

    void Start() {
        
    }

    void FixedUpdate() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 1.92f, LayerMask.GetMask("Player"));

        if (hit.collider && !preparing) {
            StartCoroutine(WaitAndShoot());
        }
    }

    private IEnumerator WaitAndShoot() {
        preparing = true;
        yield return new WaitForSeconds(0.2f);
        
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = new Vector3(
            transform.position.x + transform.localScale.x * 0.24f,
            transform.position.y,
            transform.position.z
        );
        bullet.transform.localScale = new Vector3(
            bullet.transform.localScale.x * transform.localScale.x,
            bullet.transform.localScale.y,
            bullet.transform.localScale.z
        );

        yield return new WaitForSeconds(1.0f);
        preparing = false;
    }
}
