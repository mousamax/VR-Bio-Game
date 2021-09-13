using DigestiveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSnapper : MonoBehaviour
{
    private Vector3 _magazinePosition = new Vector3(0.231000215f, 0.618000031f, 0.554999352f);
    private void OnCollisionEnter(Collision collision)
    {
        if (this.GetComponent<OVRGrabbable>().isGrabbed && collision.gameObject.CompareTag("Gun") && this.gameObject.GetComponent<AmmoActivation>().activated && collision.gameObject.GetComponent<PepsinShooter>().MagazineFound == false)
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
            this.gameObject.transform.localPosition = _magazinePosition;
            var magaziner = collision.gameObject.GetComponent<PepsinShooter>();
            magaziner._bulletIndex = 0;
            magaziner.CanShoot = true;
            magaziner.MagazineFound = true;
        }
    }
}
