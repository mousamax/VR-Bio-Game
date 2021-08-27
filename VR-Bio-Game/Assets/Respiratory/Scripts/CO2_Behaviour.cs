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
    int differenceTime;
    int speed;
    [SerializeField] Color32 NewBloodColor = new Color32(0x66, 0x0c, 0x0c, 255);

    void Start()
    {
        previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //FOR CO2 MOVEMENT
        //currenttime = time.time;
        //if (currenttime - previoustime >= differencetime)
        //{

        //    int x = random.range(0, 180);
        //    int y = random.range(0, 180);
        //    int z = random.range(0, 180);
        //    vector3 r = new vector3(x, y, z);
        //    this.transform.forward = r;
        //    this.transform.position += this.transform.forward * speed * time.deltatime;
        //    previoustime = time.time;
        //}
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.tag == "Blood")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = NewBloodColor;
        }
    }

}
