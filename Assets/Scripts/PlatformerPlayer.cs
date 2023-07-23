using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<Camera>().aspect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
