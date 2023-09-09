using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupController : MonoBehaviour
{
    public void LoadLevel() {
        SceneManager.LoadScene("Level01");
    }

    public void ShowCredits() {
        
    }
}
