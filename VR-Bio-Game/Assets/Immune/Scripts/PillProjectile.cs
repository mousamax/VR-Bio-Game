using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_Thurst = 10;
    Rigidbody rigidbody;
    public GameObject explosionEffect;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
  
        //Press A to throw the pill farward and activate the gravity
        if (gameObject.GetComponent<Weapons>().isSelected()==true && Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A is pressed");
            rigidbody.AddForce(0, m_Thurst, m_Thurst * 3, ForceMode.Impulse);
            rigidbody.useGravity = true;
            Debug.Log("Pill is Projected");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.tag == "External" || GO.tag == "Slime" || GO.tag == "Spike" || GO.tag == "FatBlob" || GO.tag == "RedCell")
        {
            Debug.Log("Pill is collided");
            GameObject explosion;
            for (int i = 0; i < 5; i++)
            {
                explosion = explosionEffect.transform.GetChild(i).gameObject;
                if (!explosion.activeSelf)
                {
                    Vector3 position = transform.position;
                    Quaternion rotation = transform.rotation;

                    explosion.SetActive(true);
                    explosion.transform.position = position;
                    explosion.transform.rotation = rotation;
                    Debug.Log("Pill is exploded");
                    break;
                }
            }
            this.transform.position = new Vector3(-70, -70, -70);
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            this.gameObject.SetActive(false);
        }

    }

}
