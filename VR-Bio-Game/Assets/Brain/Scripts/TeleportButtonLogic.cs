using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButtonLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "BrainButton")
        {
            SceneManager.LoadScene("BrainRoom");
        }
        else if (this.gameObject.name == "RespirationButton")
        {
            // SceneManager.LoadScene("BrainRoom");
        }
        else if (this.gameObject.name == "DigestionButton")
        {
            // SceneManager.LoadScene("BrainRoom");
        }
        else if (this.gameObject.name == "ImmuneButton")
        {
            // SceneManager.LoadScene("BrainRoom");
        }

    }
}
