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
        GameObject blue;
        if (collision.gameObject.tag == "Corridor")
        {
            for (int i = 0; i < 5; i++)
            {
                blue = collisionPrefabBlue.transform.GetChild(i).gameObject;
                if (!blue.activeSelf)
                {
                    // randomly choose a spawning point and instantiate one of the monsters
                    Vector3 position = transform.position;
                    Quaternion rotation = transform.rotation;

                    blue.SetActive(true);
                    blue.transform.position = position;
                    blue.transform.rotation = rotation;
                    break;
                }
            }
        }
        this.gameObject.SetActive(false);
    }
}
