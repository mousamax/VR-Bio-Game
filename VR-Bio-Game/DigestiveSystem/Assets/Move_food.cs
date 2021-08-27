using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(700 * Time.deltaTime, 0, 0);
    }
}
