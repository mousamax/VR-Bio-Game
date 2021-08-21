using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletVisibilty : MonoBehaviour
{
    public Transform activePoint;
    private bool visibilty = false;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            activePoint.position = this.transform.position;
            activePoint.rotation = this.transform.rotation;
            activePoint.gameObject.SetActive(!visibilty);
            visibilty = !visibilty;
        }
    }
}
