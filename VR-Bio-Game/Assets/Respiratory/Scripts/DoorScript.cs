using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public int score = 0; //Temporary until merging with game manager
    public AudioSource CollisionSound;
    //public BloodCellsSpawnerScript BCCSS;
    void Start()
    {
        CollisionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        BloodCellsSpawnerScript.bloodCellsCounter--;
        CollisionSound.Play();
        if(collider.gameObject.tag == "OxygenatedBlood")
        {
            //score++;
            GameManager._gameManager.ChangeStatus(0, 5);            
        }
        else if(collider.gameObject.tag=="CarbonizedBlood")
        {
            //score--;
           GameManager._gameManager.ChangeStatus(0, -2);
        }
        //destroy disables grabbing!!
        //Destroy(collider.gameObject);
        collider.gameObject.SetActive(false);
    }

    private void test()
    {
        Debug.Log("test");
    }
}
