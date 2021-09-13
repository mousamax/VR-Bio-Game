using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public static Tutorial _Tutorial;
    public bool OnTutorialMode = true;
    public GameObject TutorialTablet;
    public GameObject LeftHand;
    public int TutorialIndex = 0;
    [HideInInspector] public string[] TutorialScripts;
    public void Start()
    {
        NullSafety();
        _Tutorial = this;
    }
    public void Update()
    {
        NullSafety();
        if (OnTutorialMode && TutorialIndex < TutorialScripts.Length)
        {
            TutorialTablet.GetComponent<TutorialTablet>().ChangeScript(TutorialScripts[TutorialIndex]);
        }
        if (OnTutorialMode && TutorialIndex == TutorialScripts.Length - 1)
        {
            TutorialSkip();
        }
    }
    virtual public void TutorialNext()
    {
        TutorialIndex++;
    }

    virtual public void TutorialSkip()
    {
        OnTutorialMode = false;
        if (LeftHand != null && LeftHand.GetComponent<TabletVisibilty>() != null)
            LeftHand.GetComponent<TabletVisibilty>().enabled = true;
    }
    // public void TutorialSkip()
    // {
    //     if (SceneManager.GetActiveScene().name == "BrainRoom")
    //     {
    //         if (LeftHand != null && LeftHand.GetComponent<TabletVisibilty>() != null)
    //             LeftHand.GetComponent<TabletVisibilty>().enabled = true;
    //     }
    //     OnTutorialMode = false;
    //     Time.timeScale = 1;
    // }
    public void TutorialReset()
    {
        TutorialIndex = 0;
        OnTutorialMode = true;
    }

    private void NullSafety()
    {
        if (_Tutorial == null)
        {
            Debug.Log("Renew Tutorial");
            _Tutorial = this;
        }
        if (LeftHand == null)
        {
            LeftHand = GameObject.Find("LeftHandAnchor");
        }
        if (TutorialTablet == null)
        {
            TutorialTablet = GameObject.Find("TutorialTablet");
        }
    }
}
