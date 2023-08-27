using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcodedParticles : MonoBehaviour
{
    void Start() {
        for (int i=0; i < gameObject.transform.childCount; i++) {
            Transform pivot = gameObject.transform.GetChild(i);
            Transform particle = pivot.GetChild(0);

            pivot.localEulerAngles = new Vector3(
                pivot.localEulerAngles.x,
                pivot.localEulerAngles.y,
                pivot.localEulerAngles.z + Random.value * 90.0f
            );
            
            Vector3 offset = particle.position - transform.position;
            particle.gameObject.GetComponent<Rigidbody2D>().velocity = offset * 40.0f;            
        }
        StartCoroutine(WaitAndDie());
    }

    private IEnumerator WaitAndDie() {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
