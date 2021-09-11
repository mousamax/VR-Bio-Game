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
    public Transform leftHolister;
    public Transform rightHolister;
    public Transform trackingSpace;
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
            Pill.transform.position = weaponPlace.position;
            Pill.transform.rotation = weaponPlace.rotation;
            Pill.GetComponent<Weapons>().Select(true);
        }
        //else
        //    PillResetPosition(false);
        if (Input.GetKeyDown(KeyCode.G))
        {

            Gun.transform.position = weaponPlace.position;
            Gun.transform.rotation = weaponPlace.rotation * Quaternion.Euler(0, 180, 0);
            Gun.GetComponent<Weapons>().Select(true);
        }
        //else
        //    GunResetPosition(false);
        if (Input.GetKeyDown(KeyCode.S))
        {

            Sword.transform.position = weaponPlace.position;
            Sword.transform.rotation = weaponPlace.rotation;
            Sword.GetComponent<Weapons>().Select(true);
        }
        //else
        //    SwordResetPosition(false);
        //FOR VR PLAYING MODE
        if (Pill.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Pill.GetComponent<Weapons>().Select(true);
            //Pill.GetComponent<Rigidbody>().useGravity = false;
            //Pill.GetComponent<Rigidbody>().isKinematic = false;
        }
         if (Gun.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Gun.GetComponent<Weapons>().Select(true);
            Gun.GetComponent<Rigidbody>().useGravity = false;
            PillResetPosition(true);
        }
         else
            GunResetPosition(true);
        if (Sword.GetComponent<OVRGrabbable>().isGrabbed)
        {
            Debug.Log("The sword is grabbed");
            Sword.GetComponent<Weapons>().Select(true);
            Sword.GetComponent<Rigidbody>().isKinematic = false;
            PillResetPosition(true);

        }
        else
            SwordResetPosition(true);
    }

    private void PillResetPosition(bool VR)
    {
        if (!VR)
            Pill.transform.position = PillPlace.position;
        else
        {
            Pill.transform.position = new Vector3(trackingSpace.position.x, trackingSpace.position.y + 0.7f, trackingSpace.position.z+0.5f);
            Pill.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        Pill.GetComponent<Weapons>().Select(false);
        Pill.GetComponent<Rigidbody>().useGravity = false;
        Pill.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void SwordResetPosition(bool VR)
    {
        if (!VR)
            Sword.transform.position = SwordPlace.position;
        else
        {
            Sword.transform.position = leftHolister.position;
            Sword.transform.rotation = Quaternion.Euler(79, 0, 0);
        }
        Sword.GetComponent<Weapons>().Select(false);
        Sword.GetComponent<Rigidbody>().useGravity = false;
        Sword.GetComponent<Rigidbody>().isKinematic = true;

    }
    private void GunResetPosition(bool VR)
    {
        if (!VR)
            Gun.transform.position = GunPlace.position;
        else
        {
            Gun.transform.position = rightHolister.position;
            Gun.transform.rotation = Quaternion.Euler(-90, 180, 0);
        }
        Gun.GetComponent<Weapons>().Select(false);
        Gun.GetComponent<Rigidbody>().useGravity = false;

    }
}
