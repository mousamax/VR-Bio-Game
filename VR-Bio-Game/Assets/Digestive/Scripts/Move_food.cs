using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_food : MonoBehaviour
{
    // Start is called before the first frame update
    public void Destruct()
    {
        Destroy(this.gameObject);
    }
    public bool isDestroy = false;
    void Start()
    {
        //Invoke("Destruct", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if(isDestroy == true)
        //{
        //    Destruct();
        //}

        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(700 * Time.deltaTime, 0, 0);
    }
}
