using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2_Froce : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.tag == "Blood")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = new Color32(0x66, 0x0c, 0x0c, 255);
        }
    }
}
