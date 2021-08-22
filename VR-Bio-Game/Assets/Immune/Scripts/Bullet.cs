using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public float speed = 10f;
    Rigidbody rb;
     public GameObject collisionPrefabBlue;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bullet is created");
        //Initialize the variables
        rb = GetComponent<Rigidbody>();

        //moveTheBullet
        //rb.velocity = transform.forward * speed * Time.deltaTime;
    }
    private void Update()
    {
        //moving the bullet 
        //transform.position += transform.forward * speed * Time.deltaTime;
        transform.Translate(0, 0, speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Corridor")
        {
            Instantiate(collisionPrefabBlue, this.transform.position, this.transform.rotation);
        }
        Destroy(this.gameObject);
    }
}
