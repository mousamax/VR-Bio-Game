using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_destroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       

           Destroy(other.transform.gameObject);
            
        
    }
}
