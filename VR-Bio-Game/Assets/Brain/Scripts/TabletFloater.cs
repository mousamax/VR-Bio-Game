using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletFloater : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public bool isPicked = false;

    // Position Storage Variables
    public Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Update is called once per frame
    void Update()
    {
        if (isPicked || gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            gameObject.GetComponent<TabletFloater>().enabled = false;
        }
        else
        {
            // Spin object around Y-Axis
            transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

            // Float up/down with a Sin()
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }
    }
}
