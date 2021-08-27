using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class    move_camera : MonoBehaviour
{
    float _x = 0;
    float _y = 0;
    float _mouseSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _x -= _mouseSpeed * Input.GetAxis("Mouse Y");
        _y += _mouseSpeed * Input.GetAxis("Mouse X");

        this.transform.eulerAngles = new Vector3(_x, _y, 0f);
    }
}
