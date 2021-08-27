using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float SpawningTime = 0f;
    public float StartSpawningAfter = 0f;
     

    public GameObject[] Food;
    public Transform SpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", StartSpawningAfter, SpawningTime);
        Random.InitState(System.Environment.TickCount);
    }
    void SpawnFood()
    {
        int index = Random.Range(0, Food.Length-1);

        GameObject _spawnedFood = Instantiate(Food[index]);
        _spawnedFood.transform.position = SpawnPosition.position;
        _spawnedFood.AddComponent<Move_food>();
        
        
        
    }
}
