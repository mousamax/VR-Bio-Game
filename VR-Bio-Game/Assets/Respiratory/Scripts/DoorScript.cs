using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public int score = 0; //Temporary until merging with game manager
    public AudioSource CollisionSound;
    public GameManager GM;
    public BloodCellsSpawnerScript BCCSS;
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
        CollisionSound.Play();
        if(collider.gameObject.tag == "OxygenatedBlood")
        {
            //score++;
            GM.ChangeStatus(0, 5);
            
        }
        else if(collider.gameObject.tag=="CarbonizedBlood")
        {
            //score--;
            GM.ChangeStatus(0, -5);
        }
        Destroy(collider.gameObject);
        BCCSS.bloodCellsCounter--;
    }
}
