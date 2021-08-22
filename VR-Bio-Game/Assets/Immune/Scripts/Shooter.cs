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
    float fireRateRifle = 0.02f;
    float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        Gun.transform.position = weaponPlace.transform.position;
        Gun.transform.rotation = weaponPlace.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {        //GameObject bulletGameObject = Instantiate(bulletParent, nozzle.transform.position, nozzle.transform.rotation);

        GameObject bullet;
        for (int i = 0; i < 10; i++)
        {
            bullet = bulletParent.transform.GetChild(i).gameObject;
            if (!bullet.activeSelf)
            {
                // randomly choose a spawning point and instantiate one of the monsters
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
