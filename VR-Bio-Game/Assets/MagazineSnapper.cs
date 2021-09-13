using DigestiveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSnapper : MonoBehaviour
{
    private Vector3 _magazinePosition = new Vector3(0.231000215f, 0.618000031f, 0.554999352f);
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gun") && collision.gameObject.GetComponent<PepsinShooter>().CanShoot == false)
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
            this.gameObject.transform.position = _magazinePosition;
        }
    }
}
