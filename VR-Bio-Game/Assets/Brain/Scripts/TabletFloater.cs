using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletFloater : MonoBehaviour
{
    public float amplitude = 0.0005f;
    public float frequency = 0.8f;
    public bool isPicked = false;

    // Position Storage Variables
    public Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    void Update()
    {
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

    }
}
