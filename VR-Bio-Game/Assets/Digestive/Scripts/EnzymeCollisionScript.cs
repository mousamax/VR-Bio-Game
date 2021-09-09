using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnzymeCollisionScript : MonoBehaviour
{

    public Color AminoColor;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if ( gameObject.CompareTag("Pepsin") && collision.rigidbody.CompareTag("Protein") )
        {
            Debug.Log("Collided!");
            collision.rigidbody.tag = "Amino";
            collision.gameObject.GetComponent<Renderer>().material.color = AminoColor;

         
        }
        else
        {
            Debug.Log("No Collision");
        }
    }
}
