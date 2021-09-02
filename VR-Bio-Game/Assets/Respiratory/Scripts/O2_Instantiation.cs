using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2_Instantiation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject O2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(O2, this.transform.position, this.transform.rotation);
            O2.tag = "Moving_O2";
        }
    }
}
