using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigestiveSystem
{


    public class DigestiveBullet : MonoBehaviour
    {

        [SerializeField] public float speed = 10f;
        //public GameObject collisionPrefabBlue;

        private float _prevoiusTime = 0;

        private void Update()
        {
            //moving the bullet 
            if (this.gameObject.activeSelf)
            {

                //transform.Translate(0, 0, -speed * Time.deltaTime);
                this.transform.position += this.transform.forward.normalized * speed * Time.deltaTime;

            }
            
            if (_prevoiusTime > 4)
            {
                this.gameObject.SetActive(false);
                _prevoiusTime = 0;
            }
            _prevoiusTime += Time.deltaTime;
        }
        private void OnTriggerEnter(Collider collision)
        {
            //Debug.Log("Get collided with: " + collision.gameObject.tag);

            //if(!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Hammer") && collision.gameObject.layer != 10)
            //{

            //    Destroy(collision.gameObject);


            //}
            if (collision.gameObject.CompareTag("BloodCells"))
            {
                this.gameObject.SetActive(false);
            }
            if (collision.gameObject.CompareTag("Protein") )
            {
                Destroy(collision.gameObject);
                this.gameObject.SetActive(false);
            }
            //this.transform.position = new Vector3(-70, -70, -70);
            //this.gameObject.SetActive(false);

            //if (collision.CompareTag("StomachWall"))
            //{
            //    this.gameObject.SetActive(false);
            //}


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

