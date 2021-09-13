using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroyer : MonoBehaviour
{

    public GameObject MinimumY;


    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < MinimumY.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
