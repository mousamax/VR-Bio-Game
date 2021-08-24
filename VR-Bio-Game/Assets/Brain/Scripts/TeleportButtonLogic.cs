using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButtonLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || true)
        {
            if (this.gameObject.name == "BrainButton")
            {
                SceneLoader._sceneLoader.LoadScene("BrainRoom");
            }
            else if (this.gameObject.name == "RespirationButton")
            {
                SceneLoader._sceneLoader.LoadScene("BrainRoom 1");
            }
            else if (this.gameObject.name == "DigestionButton")
            {
                SceneLoader._sceneLoader.LoadScene("BrainRoom 1");
            }
            else if (this.gameObject.name == "ImmuneButton")
            {
                SceneLoader._sceneLoader.LoadScene("BrainRoom 1");
            }
        }
    }
}
