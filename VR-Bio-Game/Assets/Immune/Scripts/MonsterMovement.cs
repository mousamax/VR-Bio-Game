using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thurst = -1.5f;
    float health;
    public GameObject collisionPrefabGreen;
    public GameObject collisionPrefabRed;
    public GameObject collisionPrefabGold;

    // Start is called before the first frame update
    void Start()
    {
        resetHealth();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 forceapplied = new Vector3(0, 0, 1) * m_Thurst * Time.deltaTime;
        //m_Rigidbody.AddForce(0, 0, m_Thurst, ForceMode.Acceleration);
        this.transform.position += this.transform.forward * m_Thurst * Time.deltaTime;
    }

    public void reduceHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            killMonster();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "External")
        {
            this.transform.position = new Vector3(-70, -70, -70);
            resetHealth();
            this.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player")
        {
            resetHealth();
            killMonster();
        }
        if (collision.gameObject.tag == "Bullet")
            reduceHealth(20);
        else if (collision.gameObject.tag == "sword")
        {
            reduceHealth(100);
        }
        else if (collision.gameObject.tag == "Pill")
        {
            reduceHealth(150);
        }
    }

    
    private void playImpact(string s)
    {
        GameObject collision = null;
        for (int i = 0; i < 5; i++)
        {
            switch (s)
            {
                case "red":
                    collision = collisionPrefabRed.transform.GetChild(i).gameObject;
                    break;
                case "green":
                    collision = collisionPrefabGreen.transform.GetChild(i).gameObject;
                    break;
                case "gold":
                    collision = collisionPrefabGold.transform.GetChild(i).gameObject;
                    break;
            }
            if (!collision.activeSelf)
            {
                // randomly choose a spawning point and instantiate one of the monsters
                Debug.Log("using particles");
                Vector3 position = transform.position;
                Quaternion rotation = transform.rotation;
                collision.SetActive(true);
                collision.transform.position = position;
                collision.transform.rotation = rotation;
                break;
            }
        }

    }

    private void killMonster()
    {
        
        
        switch (this.tag)
        {
            case "Slime":
                playImpact("green");
                break;
            case "Spike":
                playImpact("green");
                break;
            case "FatBlob":
                playImpact("gold");
                break;
            case "RedCell":
                playImpact("red");
                break;
        }
        this.transform.position = new Vector3(-70, -70, -70);
        resetHealth();
        this.gameObject.SetActive(false);
    }
    private void resetHealth() 
    {
        switch (gameObject.tag)
        {
            case "Slime":
                health = 50;
                break;
            case "Spike":
                health = 70;
                break;
            case "FatBlob":
                health = 150;
                break;
            case "RedCell":
                health = 20;
                break;
        }
    }
}
