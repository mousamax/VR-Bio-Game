using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader _sceneLoader;
    public OVROverlay overlay_Background;
    public OVROverlay overlay_LoadingText;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (_sceneLoader == null)
        {
            _sceneLoader = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(ShowOverlayAndLoad(sceneName));
    }

    IEnumerator ShowOverlayAndLoad(string sceneName)
    {
        overlay_Background.enabled = true;
        overlay_LoadingText.enabled = true;
        GameObject CenterEyeAnchor = GameObject.Find("CenterEyeAnchor");
        overlay_LoadingText.gameObject.transform.position = CenterEyeAnchor.transform.position + new Vector3(0f, 0f, 3f);


        yield return new WaitForSeconds(3.0f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }


        overlay_Background.enabled = false;
        overlay_LoadingText.enabled = false;

        yield return null;
    }
}
