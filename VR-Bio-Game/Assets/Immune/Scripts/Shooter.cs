using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
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
    {
        Debug.Log("We are shooting!");
        GameObject bulletGameObject = Instantiate(bulletPrefab, nozzle.transform.position, nozzle.transform.rotation);
        Debug.Log("The location of the bullet is ");
        Debug.Log(bulletGameObject.transform);
        //bulletGameObject.transform.forward = nozzle.transform.forward;
    }
}
