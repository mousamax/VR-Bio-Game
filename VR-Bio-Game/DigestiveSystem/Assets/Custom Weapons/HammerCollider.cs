using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollider : MonoBehaviour
{
    private int _noOfFoodComponents = 2;
    public Vector3 FoodComponentScale;
    //private void OnTriggerEnter(Collider collision)
    //{
    //    Debug.Log(collision.transform.tag);
    //    if(collision.transform.gameObject != null && collision.gameObject.CompareTag("Food"))
    //    {

    //        for (int i = 0; i < _noOfFoodComponents; i++)
    //        {
    //            createCube(collision);
    //        }

    //        //Debug.Log("food = " + collision.gameObject.name);
    //        //if(collision.GetComponent<Move_food>() != null)
    //        Destroy(collision.gameObject);

    //        //collision.GetComponent<Move_food>().isDestroy = true;
    //            //collision.gameObject.SetActive(false);
         
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.tag);
        if (collision.transform.gameObject != null && collision.gameObject.CompareTag("Food"))
        {

            for (int i = 0; i < _noOfFoodComponents; i++)
            {
                createCube(collision);
            }

            //Debug.Log("food = " + collision.gameObject.name);
            //if(collision.GetComponent<Move_food>() != null)
            Destroy(collision.gameObject);

            //collision.GetComponent<Move_food>().isDestroy = true;
            //collision.gameObject.SetActive(false);

        }
    }


    private void createCube(Collision collision)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = collision.transform.position;
        cube.transform.localScale = FoodComponentScale;
        cube.AddComponent<Rigidbody>();
        cube.AddComponent<BoxCollider>();
    }
}
