using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTablet : MonoBehaviour
{
    public bool isPicked = false;
    public bool isOn = false;
    public AudioSource ringtone;
    public Image Screen;
    public GameObject ScreenContent;
    public TextMeshProUGUI TutorialScript;
    void Update()
    {
        ScreenContent.SetActive(isOn);
        if (isPicked || gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            gameObject.GetComponent<TabletFloater>().enabled = false;
            CancelInvoke("ScreenColorChange");
            ringtone.enabled = false;
            Color tempcolor;
            if (ColorUtility.TryParseHtmlString("#FFE194", out tempcolor))
            {
                Screen.color = tempcolor;
            }
            else
            {
                Screen.color = Color.white;
            }

            isOn = true;
        }
        else
        {
            if (!ringtone.enabled)
            {
                isOn = false;
                Screen.color = Color.black;
            }
            gameObject.GetComponent<TabletFloater>().enabled = true;
        }
    }
    public void newNotification()
    {
        InvokeRepeating("ScreenColorChange", 0.0f, 1.0f);
        ringtone.enabled = true;
    }
    void ScreenColorChange()
    {
        Screen.color = Screen.color == Color.white ? Color.black : Color.white;
    }

    public void ScreenOff()
    {
        isOn = false;
        Screen.color = Color.black;
    }

    public void ChangeScript(string script)
    {
        TutorialScript.text = script;
    }
}
