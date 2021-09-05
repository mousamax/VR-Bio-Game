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
        PillResetPosition(true);
        SwordResetPosition(true);
        GunResetPosition(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Press P to summon the pill at the weapon place
        if (Input.GetKeyDown(KeyCode.P))
        {
            GunResetPosition(false);
            SwordResetPosition(false);
            Pill.transform.position = weaponPlace.position;
            Pill.transform.rotation = weaponPlace.rotation;
            Pill.GetComponent<Weapons>().Select(true);

        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            PillResetPosition(false);
            SwordResetPosition(false);
            Gun.transform.position = weaponPlace.position;
            Gun.transform.rotation = weaponPlace.rotation * Quaternion.Euler(0, 180, 0);
            Gun.GetComponent<Weapons>().Select(true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PillResetPosition(false) ;
            GunResetPosition(false);
            Sword.transform.position = weaponPlace.position;
            Sword.transform.rotation = weaponPlace.rotation;
            Sword.GetComponent<Weapons>().Select(true);
        }
        //FOR VR PLAYING MODE
        if (Pill.GetComponent<OVRGrabbable>().isGrabbed)
        {
            GunResetPosition(true);
            SwordResetPosition(true);
            Pill.GetComponent<Weapons>().Select(true);
            Pill.GetComponent<Rigidbody>().useGravity = true;
            Pill.GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (Gun.GetComponent<OVRGrabbable>().isGrabbed)
        {
            PillResetPosition(true);
            SwordResetPosition(true);
            Gun.GetComponent<Weapons>().Select(true);
            Gun.GetComponent<Rigidbody>().useGravity = true;

        }
        else if (Sword.GetComponent<OVRGrabbable>().isGrabbed)
        {
            PillResetPosition(true);
            GunResetPosition(true);
            Sword.GetComponent<Weapons>().Select(true);
            Sword.GetComponent<Rigidbody>().useGravity = true;

        }
    }

    private void PillResetPosition(bool VR)
    {
        if (!VR)
            Pill.transform.position = PillPlace.position;
        Pill.GetComponent<Weapons>().Select(false);
        Pill.GetComponent<Rigidbody>().useGravity = false;
    }
    private void SwordResetPosition(bool VR)
    {
        if (!VR)
            Sword.transform.position = SwordPlace.position;
        Sword.GetComponent<Weapons>().Select(false);
        Sword.GetComponent<Rigidbody>().useGravity = false;


    }
    private void GunResetPosition(bool VR)
    {
        if (!VR)
            Gun.transform.position = GunPlace.position;
        Gun.GetComponent<Weapons>().Select(false);
        Gun.GetComponent<Rigidbody>().useGravity = false;

    }
}
