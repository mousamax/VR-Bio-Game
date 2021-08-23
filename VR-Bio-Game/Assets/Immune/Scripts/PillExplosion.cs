using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillExplosion : MonoBehaviour
{

    // public GameObject explosionEffect;
    public float radius = 1000;
    float timer;

    void Start()
    {
        timer = 0;
        // returns an array of all the colliders with the sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); 
        
        foreach (Collider nearbyObject in colliders)
        {
            Debug.Log("Found a collider");
            nearbyObject.GetComponent<MonsterHit>().reduceHealth(200);
        }
    }

}
