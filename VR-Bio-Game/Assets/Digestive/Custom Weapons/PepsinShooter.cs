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
        public bool CanShoot;
                
        private int _maxBullets;
        public int MagazineIndex = 1;
        //private static int _bulletIndex = 0;

        //AudioSource gunAudioSource;

        //private void Start()
        //{
        //    gunAudioSource = Gun.GetComponent<AudioSource>();
        //}

        private void Start()
        {
            _maxBullets = bulletParent.transform.childCount;
            CanShoot = true;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) || (this.GetComponent<OVRGrabbable>().isGrabbed && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)))
            {
                Shoot();
            }
            if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Two))
            {
                this.gameObject.transform.GetChild(MagazineIndex).GetComponent<Rigidbody>().isKinematic = false;
            }

            
        }

        private void Shoot()
        {

            GameObject bullet;
            if (CanShoot)
            {
                for (int i = 0; i < _maxBullets; i++)
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
                        bullet.transform.forward = this.transform.forward;

                        break;
                    }
                    if (i == _maxBullets - 1)
                    {
                        CanShoot = false;
                    }

                }
            }
            
        }
    }

}
