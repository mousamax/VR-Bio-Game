using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float _mouseSpeed = 10;
    float _x = 0, _y = 0;
    public GameObject O2;
    
    // Update is called once per frame
    void Update()
    {
  
        _x -= _mouseSpeed * Input.GetAxis("Mouse Y");
        _y += _mouseSpeed * Input.GetAxis("Mouse X");

        this.transform.eulerAngles = new Vector3(0, _y, 0f);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(O2, this.transform.position, this.transform.rotation);
        }
    }
}

