using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillExplosion : MonoBehaviour
{

    // public GameObject explosionEffect;
    float radius;
    void Start()
    {
        radius = 1000;
        // returns an array of all the colliders with the sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Debug.Log("number of colliders is: " + colliders.Length);

        foreach (Collider nearbyObject in colliders)
        {
            
            MonsterHit monster = nearbyObject.GetComponent<MonsterHit>();
            if(monster != null)
            {
                monster.reduceHealth(200);
            }
        }
    }

}
