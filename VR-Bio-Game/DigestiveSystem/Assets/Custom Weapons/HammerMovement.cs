using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerMovement : MonoBehaviour
{
    public GameObject plane;
    Vector3 m_EulerAngleVelocity;
    Rigidbody rb;
    bool hitGround = false;
    bool buttonClick = false;
    Vector3 maxLimit;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        maxLimit = new Vector3(6,106,96);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            buttonClick = true;
            //Debug.Log("Left Mouse");
            hitGround = false;
            

        }
        if (buttonClick == true && hitGround == false)
        {

            
            m_EulerAngleVelocity = new Vector3(0, 0, 1000);
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            float limitReached = this.gameObject.transform.rotation.eulerAngles.x;
            //Debug.Log("hitGround = " + hitGround);

            //Debug.Log("ButtonClick" + buttonClick);
            //rb.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log(limitReached);
            if (limitReached > 6.212)
            {
                
                hitGround = true;
                buttonClick = false;
            }
        }
    }

}
