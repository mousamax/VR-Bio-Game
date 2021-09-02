using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsTablet : MonoBehaviour
{
    public bool isPicked = false;
    public bool isOn = false;
    public AudioSource ringtone;
    public Image Screen;
    public GameObject ScreenContent;
    void Update()
    {
        ScreenContent.SetActive(isOn);
        if (isPicked || gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            CancelInvoke("ScreenColorChange");
            ringtone.enabled = false;
            Screen.color = Color.white;
            isOn = true;
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
    }
}
