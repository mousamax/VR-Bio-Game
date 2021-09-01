using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (this.gameObject.name == "NextButton" && other.tag == "PlayerFingers")
        {
            Debug.Log("next");
            GameManager._gameManager.TutorialNext();
        }
        else if (this.gameObject.name == "SkipButton" && other.tag == "Player")
        {
            Debug.Log("skip");
            GameManager._gameManager.TutorialSkip();
        }
    }
}
