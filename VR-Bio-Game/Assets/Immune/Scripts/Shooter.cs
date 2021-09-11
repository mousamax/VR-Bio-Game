using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject bulletParent;
    public GameObject nozzle;
    public GameObject weaponPlace;
    public GameObject Gun;
    [SerializeField] float firerate;
    float timer;
    int ammo = 200;

    AudioSource gunAudioSource;

    private void Start()
    {
        gunAudioSource = Gun.GetComponent<AudioSource>();
        firerate = 0.1f;
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>firerate && Gun.GetComponent<Weapons>().isSelected() == true && (Input.GetMouseButtonDown(0) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger)))
        {
            Shoot();
            timer = 0;
        }
    }
    private void Shoot()
    {
        if (ammo == 0)
            return;
        ammo--;
        GameObject bullet;
        for (int i = 0; i < 10; i++)
        {
            bullet = bulletParent.transform.GetChild(i).gameObject;
            if (!bullet.activeSelf)
            {
                Vector3 position = new Vector3(nozzle.transform.position.x, nozzle.transform.position.y, nozzle.transform.position.z + 1.5f);
                Quaternion rotation = nozzle.transform.rotation;
                gunAudioSource.Play();

                bullet.SetActive(true);
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                break;
            }
        }
    }
}
