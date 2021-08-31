using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTablet : MonoBehaviour
{
    public static GameObject _TutorialTablet;
    public bool isPicked = false;
    public bool isOn = false;
    public AudioSource ringtone;
    public Image Screen;
    public GameObject ScreenContent;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (_TutorialTablet == null)
        {
            _TutorialTablet = this.gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (_TutorialTablet == null)
        {
            Debug.Log("Renew TutorialTablet");
            _TutorialTablet = this.gameObject;
        }
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
}
