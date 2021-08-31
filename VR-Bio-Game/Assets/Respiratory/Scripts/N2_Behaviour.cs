using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditor;
using UnityEngine;

public class N2_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousTime;
    private float currentTime;
    public int differenceTime = 2;
    public int speed = 2;
    [SerializeField] Color32 NewBloodColor = new Color32(0x66, 0x0c, 0x0c, 255);

    void Start()
    {
        previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //FOR N2 RANDOM MOVEMENT
    //    currentTime = Time.time;
    //    if (currentTime - previousTime >= differenceTime)
    //    {

    //        int x = Random.Range(0, 180);
    //        int z = Random.Range(0, 180);
    //        float y = this.transform.forward.y;
    //        Vector3 r = new Vector3(x, y, z);
    //        this.transform.forward = r;
    //        previousTime = Time.time;
    //    }
    //    this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Blood")
    //    {
    //        Destroy(this.gameObject);
    //        collision.gameObject.GetComponent<Renderer>().material.color = NewBloodColor;
    //    }
    //    if (collision.gameObject.tag == "Door1" || collision.gameObject.tag == "Door2")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

}


