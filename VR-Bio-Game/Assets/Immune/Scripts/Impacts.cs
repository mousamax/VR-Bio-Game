using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impacts : MonoBehaviour
{
    public float timer =0;
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                this.transform.position = new Vector3(-70, -70, -70);
                this.gameObject.SetActive(false);
                timer = 0;
            }
        }
    }
}
