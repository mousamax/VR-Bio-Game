using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportButtonLogic : MonoBehaviour
{
    public AudioSource ButtonTab;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "PlayerFingers" && true)
        {
            if (this.gameObject.name == "BrainButton")
            {
                ButtonTab.Play();
                SceneLoader._sceneLoader.LoadScene("BrainRoom");
            }
            else if (this.gameObject.name == "RespirationButton")
            {
                ButtonTab.Play();
                SceneLoader._sceneLoader.LoadScene("LungsScene");
            }
            else if (this.gameObject.name == "DigestionButton")
            {
                ButtonTab.Play();
                SceneLoader._sceneLoader.LoadScene("FinalScene");
            }
            else if (this.gameObject.name == "ImmuneButton")
            {
                ButtonTab.Play();
                SceneLoader._sceneLoader.LoadScene("WeaponHolster");
            }
        }
    }
}
