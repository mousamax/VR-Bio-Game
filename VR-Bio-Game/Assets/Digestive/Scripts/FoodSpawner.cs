using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigestiveSystem
{
    public class FoodSpawner : MonoBehaviour
    {
        public float SpawningTime = 0f;
        public float StartSpawningAfter = 0f;
        public GameObject DestroyPosition;

        public GameObject[] Food;
        public Transform SpawnPosition;
        // Start is called before the first frame update
        void Start()
        {
            CheckDifficulty();
            InvokeRepeating("SpawnFood", StartSpawningAfter, SpawningTime);
            Random.InitState(System.Environment.TickCount);
        }
        void SpawnFood()
        {
            if (!Tutorial._Tutorial.OnTutorialMode)
            {
                int index = Random.Range(0, Food.Length - 1);
                GameObject _spawnedFood = Instantiate(Food[index]);
                _spawnedFood.transform.position = SpawnPosition.position;
                _spawnedFood.AddComponent<Move_food>();

                _spawnedFood.AddComponent<FoodDestroyer>();
                _spawnedFood.GetComponent<FoodDestroyer>().MinimumY = DestroyPosition;
            }



        }

        void CheckDifficulty()
        {
            if (EventManager._eventManager.GetCurrentEvent() == Events.EatProkly)
            {
                switch (EventManager._eventManager.GetEventDifficulty())
                {
                    case Difficulty.Easy:
                        SpawningTime = 10;
                        break;
                    case Difficulty.Normal:
                        SpawningTime = 6;
                        break;
                    case Difficulty.Hard:
                        SpawningTime = 3;
                        break;
                    case Difficulty.Nightmare:
                        SpawningTime = 2.5f;
                        break;
                }
            }
        }
    }
}