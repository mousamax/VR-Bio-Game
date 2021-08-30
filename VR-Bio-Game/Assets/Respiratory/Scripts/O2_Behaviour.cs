using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 15f;
    [SerializeField] Color32 LightRed = new Color32(0xe2, 0x69, 0x69, 255); 
    // Update is called once per frame
    void FixedUpdate()
    {
        //FOR O2 MOVEMENT
        //this.transform.position += this.transform.forward * speed * Time.deltaTime;

    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Blood")
        {
            //Destroy(this.gameObject);
            collider.gameObject.GetComponent<Renderer>().material.color = LightRed;
            collider.gameObject.tag = "OxygenatedBlood";
        }

    }
}
