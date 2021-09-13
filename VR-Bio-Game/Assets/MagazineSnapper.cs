using DigestiveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSnapper : MonoBehaviour
{

    private Vector3 _magazinePosition = new Vector3(0.231000215f, 0.618000031f, 0.554999352f);
    private Quaternion _magazineQuat = new Quaternion(0.995064914f, 0.0337990448f, 0.0924226418f, 0.0127044627f);
    public bool OldMagazine;
    public GameObject MagazinePosition;
    private void OnCollisionEnter(Collision collision)
    {//!this.GetComponent<OVRGrabbable>().isGrabbed && 
        if (collision.gameObject.CompareTag("Gun") && !OldMagazine)
        {
            this.transform.GetComponent<Rigidbody>().isKinematic = true;
            
            this.gameObject.transform.parent = collision.gameObject.transform;
            this.gameObject.transform.position = MagazinePosition.transform.position;
            this.gameObject.transform.rotation = MagazinePosition.transform.rotation;
            var magaziner = collision.gameObject.GetComponent<PepsinShooter>();
            magaziner._bulletIndex = 0;
            magaziner.CanShoot = true;
            magaziner.MagazineFound = true;
        }
    }

    
}
