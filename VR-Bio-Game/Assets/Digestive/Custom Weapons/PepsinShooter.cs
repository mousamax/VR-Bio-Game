using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigestiveSystem
{
    public class PepsinShooter : MonoBehaviour
    {
        //[SerializeField] AudioClip shootClip;

        public GameObject bulletParent;
        public GameObject nozzle;
        //public GameObject weaponPlace;
        public GameObject Gun;

        //AudioSource gunAudioSource;

        //private void Start()
        //{
        //    gunAudioSource = Gun.GetComponent<AudioSource>();
        //}


        void Update()
        {
            //OVRInput.Get(OVRInput.RawButton.RIndexTrigger)
            if (Input.GetMouseButtonDown(0) || (Gun.GetComponent<OVRGrabbable>().isGrabbed && OVRInput.Get(OVRInput.RawButton.RIndexTrigger)))
            {
                Shoot();
            }
        }

        private void Shoot()
        {

            GameObject bullet;
            for (int i = 0; i < 10; i++)
            {
                bullet = bulletParent.transform.GetChild(i).gameObject;
                if (!bullet.activeSelf)
                {
                    Vector3 position = nozzle.transform.position;
                    Quaternion rotation = nozzle.transform.rotation;
                    //rotation.eulerAngles.z += 
                    //gunAudioSource.PlayOneShot(shootClip);
                    //Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    //Vector3 m_EulerAngleVelocity = new Vector3(0, 0, 270);
                    //Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity);
                    //rb.MoveRotation(rb.rotation * deltaRotation);
                    bullet.SetActive(true);
                    bullet.transform.position = position;
                    bullet.transform.rotation = rotation;
                    
                    break;
                }
                if (i == 9)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        bullet = bulletParent.transform.GetChild(j).gameObject;
                        bullet.SetActive(false);
                    }
                }

            }
        }
    }

}
