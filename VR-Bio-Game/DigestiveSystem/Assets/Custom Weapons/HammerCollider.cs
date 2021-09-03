using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollider : MonoBehaviour
{
    private int _noOfFoodComponents = 2;
    public Vector3 FoodComponentScale;

    public GameObject Protein;
    public GameObject Carb;
    public GameObject Fats;

    private Vector3 _proteinScale = new Vector3(0.005f, 0.005f, 0.005f);

    private void OnCollisionEnter(Collision collision)
    {
        // 0 -> protein
        // 1 -> fats
        // 2 -> carbs

        if (collision.gameObject.CompareTag("Banana"))
        {
            createFoodComponent(collision, 0, 2);// 0 -> protein
            createFoodComponent(collision, 1, 1);// 1 -> fats
            createFoodComponent(collision, 2, 3);// 2 -> carbs

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Cheese"))
        {
            createFoodComponent(collision, 0, 2);
            createFoodComponent(collision, 1, 3);
            createFoodComponent(collision, 2, 1);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Cherry"))
        {
            createFoodComponent(collision, 0, 2);
            createFoodComponent(collision, 1, 1);
            createFoodComponent(collision, 2, 3);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Hamburger"))
        {
            createFoodComponent(collision, 0, 3);
            createFoodComponent(collision, 1, 2);
            createFoodComponent(collision, 2, 4);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Hotdog"))
        {
            createFoodComponent(collision, 0, 2);// 0 -> protein
            createFoodComponent(collision, 1, 3);// 1 -> fats
            createFoodComponent(collision, 2, 1);// 2 -> carbs

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Olive"))
        {
            createFoodComponent(collision, 0, 1);// 0 -> protein
            createFoodComponent(collision, 1, 3);// 1 -> fats
            createFoodComponent(collision, 2, 2);// 2 -> carbs

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Watermelon"))
        {
            createFoodComponent(collision, 0, 2);// 0 -> protein
            createFoodComponent(collision, 1, 1);// 1 -> fats
            createFoodComponent(collision, 2, 3);// 2 -> carbs

            Destroy(collision.gameObject);
        }

        
    }


    private void createFoodComponent(Collision collision, int type, int count)
    {
        // 0 -> protein
        // 1 -> fats
        // 2 -> carbs

        GameObject temp;
        if (type == 0)
        {
            //Protein
            for (int i = 0; i < count; i++)
            {
                temp = Instantiate(Protein);
                Vector3 position = collision.gameObject.transform.position;
                //position.x += (i / 2);
                //position.y += (i / 2);
                //position.z += (i * 2);
                //temp.transform.localScale = _proteinScale;
                temp.transform.position = position;
            }
        }
        else if (type == 1)
        {
            //Fats
            for (int i = 0; i < count; i++)
            {
                temp = Instantiate(Fats);
                Vector3 position = collision.gameObject.transform.position;
                //position.x += (i / 2);
                //position.y += (i / 2);
                //position.z += (i * 2);
                temp.transform.position = position;
            }
        }
        else if (type == 2)
        {
            //Carbs
            for (int i = 0; i < count; i++)
            {
                temp = Instantiate(Carb);
                Vector3 position = collision.gameObject.transform.position;
                //position.x += (i / 2);
                //position.y += (i / 2);
                //position.z += (i * 2);
                temp.transform.position = position;
            }
        }
        else
        {
            Debug.LogError("Wrong Type of food components");
            temp = null;
        }




    }
}
