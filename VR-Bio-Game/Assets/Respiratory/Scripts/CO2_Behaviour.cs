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
    int differenceTime = 2;
    public float speed = 0.5f;
    [SerializeField] Color32 Red = new Color32(0xC3, 0x15, 0x15, 255); 
     [SerializeField] Color32 DarkRed = new Color32(0x66, 0x0c, 0x0c, 255);

    void Start()
    {
        previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //FOR CO2 random MOVEMENT
        this.transform.position += this.transform.forward * speed * Time.deltaTime;


    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Blood")
        //{
        //    Destroy(this.gameObject);
        //    collision.gameObject.GetComponent<Renderer>().material.color = NewBloodColor;
        //}
        //if (collision.gameObject.tag == "Door1" || collision.gameObject.tag == "Door2")
        //{
        //    Destroy(this.gameObject);
        //}

    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "CarbonizedBlood")
        {
            collider.gameObject.GetComponent<Renderer>().material.color = Red;
            collider.gameObject.tag = "Blood";
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Blood" || collider.gameObject.tag == "OxygenatedBlood")
        {
            collider.gameObject.GetComponent<Renderer>().material.color = DarkRed;
            collider.gameObject.tag = "CarbonizedBlood";

        }
    }


}
