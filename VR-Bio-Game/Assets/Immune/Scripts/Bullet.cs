using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public float speed = 10f;
    public GameObject collisionPrefabBlue;

    private void Update()
    {
        //moving the bullet 
        if (this.gameObject.activeSelf)
            transform.Translate(0, 0, speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            //impact
            GameObject blue;
            for (int i = 0; i < 10; i++)
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
            this.transform.position = new Vector3(-70, -70, -70);
            this.gameObject.SetActive(false);
        }
    }
}

