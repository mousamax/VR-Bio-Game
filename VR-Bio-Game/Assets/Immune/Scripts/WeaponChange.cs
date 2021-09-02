using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Sword;
    public GameObject Pill;
    public Transform weaponPlace;
    public Transform SwordPlace;
    public Transform GunPlace;
    public Transform PillPlace;
    // Start is called before the first frame update
    void Start()
    {
      ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        // Press P to summon the pill at the weapon place
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetPosition();
            Pill.transform.position = weaponPlace.position;
            Pill.transform.rotation = weaponPlace.rotation;
            Pill.GetComponent<Weapons>().Select(true);

        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ResetPosition();
            Gun.transform.position = weaponPlace.position;
            Gun.transform.rotation = weaponPlace.rotation * Quaternion.Euler(0, 180, 0);
            Gun.GetComponent<Weapons>().Select(true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ResetPosition();
            Sword.transform.position = weaponPlace.position;
            Sword.transform.rotation = weaponPlace.rotation;
            Sword.GetComponent<Weapons>().Select(true);
        }
        //FOR VR PLAYING MODE
        if (Pill.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Pill.GetComponent<Weapons>().Select(true);
            Pill.GetComponent<Rigidbody>().useGravity = true;
        }
        else if (Gun.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Gun.GetComponent<Weapons>().Select(true);
            Gun.GetComponent<Rigidbody>().useGravity = true;

        }
        else if (Sword.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Sword.GetComponent<Weapons>().Select(true);
            Sword.GetComponent<Rigidbody>().useGravity = true;

        }
    }
    private void ResetPosition()
    {
        Gun.transform.position = GunPlace.position;
        Sword.transform.position = SwordPlace.position;
        Pill.transform.position = PillPlace.position;

        Gun.GetComponent<Weapons>().Select(false);
        Sword.GetComponent<Weapons>().Select(false);
        Pill.GetComponent<Weapons>().Select(false);
        Pill.GetComponent<Rigidbody>().useGravity = false;
        Gun.GetComponent<Rigidbody>().useGravity = false;
        Sword.GetComponent<Rigidbody>().useGravity = false;
    }
}
