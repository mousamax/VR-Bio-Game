using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigestiveSystem
{


    public class DigestiveBullet : MonoBehaviour
    {

        [SerializeField] public float speed = 10f;
        //public GameObject collisionPrefabBlue;

        private void Update()
        {
            //moving the bullet 
            if (this.gameObject.activeSelf)
            {

                transform.Translate(speed * Time.deltaTime, 0, 0);

            }
                
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Get collided with: " + collision.gameObject.tag);
            //if (collision.gameObject.tag == "Player")
            //    return;
            ////impact
            //GameObject blue;
            //for (int i = 0; i < 10; i++)
            //{
            //    blue = collisionPrefabBlue.transform.GetChild(i).gameObject;
            //    if (!blue.activeSelf)
            //    {
            //        // randomly choose a spawning point and instantiate one of the monsters
            //        Vector3 position = transform.position;
            //        Quaternion rotation = transform.rotation;

            //        blue.SetActive(true);
            //        blue.transform.position = position;
            //        blue.transform.rotation = rotation;
            //        break;
            //    }
            //}
            //this.transform.position = new Vector3(-70, -70, -70);
            //this.gameObject.SetActive(false);
            if(!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Hammer") && collision.gameObject.layer != 10)
            {

                Destroy(collision.gameObject);
                

            }
            if(collision.gameObject.layer == 10)
            {
                collision.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
            //if (collision.gameObject.CompareTag("Protein"))
            //{

            //}
            //if (collision.gameObject.CompareTag("Fats"))
            //{

            //}
            //if (collision.gameObject.CompareTag("Carbs"))
            //{

            //}
        }
    }
}

