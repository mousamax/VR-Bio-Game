using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonLogic : MonoBehaviour
{
    public AudioSource ButtonTab;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (this.gameObject.name == "NextButton" && other.tag == "PlayerFingers")
        {
            Debug.Log("next");
            ButtonTab.Play();
            GameManager._gameManager.TutorialNext();
        }
        else if (this.gameObject.name == "SkipButton" && other.tag == "PlayerFingers")
        {
            Debug.Log("skip");
            ButtonTab.Play();
            GameManager._gameManager.TutorialSkip();
        }
    }
}
