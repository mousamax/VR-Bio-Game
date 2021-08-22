using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impacts : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                this.gameObject.SetActive(false);
                timer = 0;
            }
        }
    }
}
