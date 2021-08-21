using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButtonLogic : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("here");
        // if (this.gameObject.name == "BrainButton")
        // {
        //     SceneManager.LoadScene("BrainRoom");
        // }
    }
}
