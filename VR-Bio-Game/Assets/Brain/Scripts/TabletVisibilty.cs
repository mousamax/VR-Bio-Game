using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletVisibilty : MonoBehaviour
{
    public Transform tablet;
    private bool isPicked = false;
    private bool visibility = false;
    void Update()
    {
        if (Input.GetButtonDown("Jump") || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            // tablet.position = this.transform.position;
            // tablet.rotation = this.transform.rotation;
            tablet.gameObject.SetActive(!visibility);
            visibility = !visibility;
        }
    }

    public void isGrabbed(bool val)
    {
        isPicked = false;
    }
}
