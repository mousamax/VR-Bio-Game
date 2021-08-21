using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] protected float timer; // the time counter
    [SerializeField] protected float spawningTime; // the time to spawn 

    public GameObject[] monstersPrefabs;
    //List<GameObject> monsters = new List<GameObject>();
    public GameObject[] arrSpawningPoint;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        spawningTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawningTime)
        {
            // randomly choose a spawning point and instantiate one of the monsters

            int index = Random.Range(0, arrSpawningPoint.Length ); // random spawning point
            Vector3 position = arrSpawningPoint[index].transform.position;

            index = Random.Range(0, monstersPrefabs.Length ); // random monster
            GameObject monster = monstersPrefabs[index];
            GameObject monsterInstance = Instantiate(monster, position, arrSpawningPoint[index].transform.rotation* Quaternion.Euler(0f,180f,0f));
            //monsters.Add(monsterInstance);
            timer = 0;
        }
    }
}
