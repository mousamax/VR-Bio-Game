using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Gases : MonoBehaviour
{
    // Start is called before the first frame update
    public Bad_Gases_Instantiation BGI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CO2" || collision.gameObject.tag=="N2")
        {
            Debug.Log("Collision\n");
            BGI.counter--;
            Destroy(collision.gameObject);
        }
    }
}
