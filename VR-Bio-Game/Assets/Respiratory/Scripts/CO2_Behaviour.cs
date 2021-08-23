using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;

public class CO2_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousTime;
    private float currentTime;
    public int differenceTime;
    public int speed;
    void Start()
    {
        previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        currentTime = Time.time;
        if (currentTime - previousTime >= differenceTime)
        {
            Vector3 pos = this.transform.position;
            pos.z-=speed*Time.deltaTime;
            this.transform.position = pos;
        //    int x = Random.Range(0, 180);
        //    int y = Random.Range(0, 180);
        //    int z = Random.Range(0, 180);
        //    Vector3 r = new Vector3(x, y, z);
        //    this.transform.forward = r;
        //    this.transform.position += this.transform.forward * speed * Time.deltaTime;
        //    previousTime = Time.time;
        }

    }
   
}
