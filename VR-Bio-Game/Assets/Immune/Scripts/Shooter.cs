using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletParent;
    public GameObject nozzle;
    public GameObject weaponPlace;
    public GameObject Gun;

    float fireRateGun = 0.1f;

    void Start()
    {
    }

    void Update()
    {
        //Gun.GetComponent<Weapons>().isSelected()==true &&
        if (Input.GetMouseButtonDown(0) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
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

                bullet.SetActive(true);
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                break;
            }

        }
    }
}
