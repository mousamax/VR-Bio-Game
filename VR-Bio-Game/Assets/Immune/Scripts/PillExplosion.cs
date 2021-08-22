using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillExplosion : MonoBehaviour
{

    public GameObject explosionEffect;
    public float radius=6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
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

       Collider[] colliders =  Physics.OverlapSphere(transform.position, radius); // returns an array of all the colliders with the sphere
        //foreach(Collider nearbyObject in colliders)
        //{
        //    nearbyObject.
        //}

        this.gameObject.SetActive(false);
    }
}
