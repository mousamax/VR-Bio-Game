using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoManager : MonoBehaviour
{
    public VideoClip[] _videoClips;
    public VideoPlayer _videoPlayer;
    public GameObject _videoSkin;
    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer.clip = null;
        _videoSkin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int eventIndicator = EventManager._eventManager.getCurrentEvent();
        if (eventIndicator == EventManager._eventManager.getNoneEvent())
        {
            _videoPlayer.clip = null;
            DisableSkin();
        }
        else
        {
            _videoPlayer.clip = _videoClips[eventIndicator];
            Invoke("EnableSkin", 0.2f);
        }
    }

    private void EnableSkin()
    {
        _videoSkin.SetActive(true);
    }

    private void DisableSkin()
    {
        _videoSkin.SetActive(false);
    }
}
