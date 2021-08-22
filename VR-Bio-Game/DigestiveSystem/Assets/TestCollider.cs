using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        Debug.Log(collision.gameObject.tag);
    }
}
