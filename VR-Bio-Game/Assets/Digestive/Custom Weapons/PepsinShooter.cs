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
        public bool CanShoot = true;

        private int _maxBullets;
        public int MagazineIndex = 1;
        public int _bulletIndex = 0;
        public bool MagazineFound = true;

        //AudioSource gunAudioSource;

        //private void Start()
        //{
        //    gunAudioSource = Gun.GetComponent<AudioSource>();
        //}

        private void Start()
        {
            _maxBullets = bulletParent.transform.childCount;
        }

        void Update()
        {
            if (CanShoot && Input.GetMouseButtonDown(0) || (this.GetComponent<OVRGrabbable>().isGrabbed && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)))
            {
                Shoot();
            }
            if (!CanShoot && Input.GetMouseButtonDown(1) || (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Two)))
            {
                 //this.gameObject.transform.GetChild(MagazineIndex);
                var child = this.gameObject.transform.Find("Magazine");
                if (child != null)
                {
                    child.GetComponent<Rigidbody>().isKinematic = false;
                    child.transform.SetParent(null);
                    child.GetComponent<AmmoActivation>().activated = false;
                    child.GetComponent<MagazineSnapper>().OldMagazine = true;
                }
                    MagazineFound = false;
                    CanShoot = false;

            }


        }

        private void Shoot()
        {

            GameObject bullet;


            bullet = bulletParent.transform.GetChild(_bulletIndex).gameObject;

            Vector3 position = nozzle.transform.position;
            Quaternion rotation = nozzle.transform.rotation;
            //rotation.eulerAngles.z += 
            //gunAudioSource.PlayOneShot(shootClip);
            //Rigidbody rb = bullet.GetComponent<Rigidbody>();
            //Vector3 m_EulerAngleVelocity = new Vector3(0, 0, 270);
            //Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity);
            //rb.MoveRotation(rb.rotation * deltaRotation);
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.transform.forward = this.transform.forward;
            bullet.SetActive(true);
            _bulletIndex++;


            if (_bulletIndex == _maxBullets - 1)
            {
                CanShoot = false;
            }




        }
    }

}
