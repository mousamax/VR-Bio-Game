using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonLogic : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "NextButton")
        {
            Debug.Log("next");
            GameManager._gameManager.TutorialNext();
        }
        else if (this.gameObject.name == "SkipButton")
        {
            Debug.Log("skip");
            GameManager._gameManager.TutorialSkip();
        }
    }
}
