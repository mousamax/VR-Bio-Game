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

                transform.Translate(0, 0, -speed * Time.deltaTime);

            }
                
        }
        private void OnTriggerEnter(Collider collision)
        {
            //Debug.Log("Get collided with: " + collision.gameObject.tag);

            //if(!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Hammer") && collision.gameObject.layer != 10)
            //{

            //    Destroy(collision.gameObject);
                

            //}
            if(collision.gameObject.CompareTag("BloodCells"))
            {
                collision.gameObject.SetActive(false);
            }
            if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
            {
                Destroy(collision.gameObject);
            }
            this.transform.position = new Vector3(-70, -70, -70);
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

