using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletParent;
    public GameObject nozzle;
    public GameObject weaponPlace;
    public GameObject Gun;


    void Update()
    {

        if (Gun.GetComponent<Weapons>().isSelected() == true && (Input.GetMouseButtonDown(0) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger)))
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
                //position.z += 4;
                Quaternion rotation = nozzle.transform.rotation;

                bullet.SetActive(true);
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                break;
            }

        }
    }
}
