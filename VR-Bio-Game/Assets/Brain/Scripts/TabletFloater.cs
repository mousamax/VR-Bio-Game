using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletFloater : MonoBehaviour
{
    public float amplitude = 0.05f;
    public float frequency = 0.8f;
    public bool isPicked = false;

    // Position Storage Variables
    public Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    void Start()
    {
        posOffset = transform.position;
    }
    void Update()
    {
        if (transform.rotation.x < 0)
        {
            Debug.Log("flip");
            Debug.Log(transform.rotation.x);
            // transform.rotation = new Quaternion(-transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        }
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude * Convert.ToInt32(!isPicked /*|| !gameObject.GetComponent<OVRGrabbable>().isGrabbed*/);

        transform.position = tempPos;

    }
}
