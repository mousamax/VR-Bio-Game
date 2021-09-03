using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BloodCellMoveScript : MonoBehaviour
{


    public float speed = 0.5f;
    // Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.position += this.gameObject.transform.forward*speed*Time.deltaTime;
        //this.gameObject.transform.position += (this.gameObject.transform.forward.normalized / 20f);

    }

   
}
