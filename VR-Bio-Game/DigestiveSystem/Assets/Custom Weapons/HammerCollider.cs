using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollider : MonoBehaviour
{
    private int _noOfFoodComponents = 2;
    public Vector3 FoodComponentScale;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food") )
        {
            for (int i = 0; i < _noOfFoodComponents; i++)
            {
                createCube(collision);
            }
            
            Destroy(collision.gameObject);
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
