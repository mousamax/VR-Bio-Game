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
        //gameObject.GetComponent<weapons>().isSelected()==true &&
        if ( Input.GetKeyDown(KeyCode.A))
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.AddForce(0, m_Thurst, m_Thurst * 2, ForceMode.Impulse);
            rigidbody.useGravity = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject GO = collision.gameObject;
        if (GO.tag == "external" || GO.tag == "Slime" || GO.tag == "Spike" || GO.tag == "FatBlob" || GO.tag == "RedCell")
        {
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
                    break;
                }
            }
            this.transform.position = new Vector3(-70, -70, -70);
            this.gameObject.SetActive(false);
        }

    }

}
