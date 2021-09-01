using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButtonLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "PlayerFingers" && true)
        {
            if (this.gameObject.name == "BrainButton")
            {
                SceneLoader._sceneLoader.LoadScene("BrainRoom");
            }
            else if (this.gameObject.name == "RespirationButton")
            {
                SceneLoader._sceneLoader.LoadScene("LungsScene");
            }
            else if (this.gameObject.name == "DigestionButton")
            {
                // SceneLoader._sceneLoader.LoadScene("BrainRoom 1");
            }
            else if (this.gameObject.name == "ImmuneButton")
            {
                SceneLoader._sceneLoader.LoadScene("ImmuneSystem");
            }
        }
    }
}
