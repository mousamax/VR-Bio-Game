using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] public float m_Thurst = -5f;
    float health;
    public GameObject collisionPrefabGreen;
    public GameObject collisionPrefabRed;
    public GameObject collisionPrefabGold;

    // Start is called before the first frame update
    void Start()
    {
        switch (this.tag)
        {
            case "Slime":
                health = 50;
                break;
            case "Spike":
                health = 70;
                break;
            case "Fatblob":
                health = 150;
                break;
            case "RedCell":
                health = 0;
                break;
        }
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
            this.gameObject.SetActive(false);
            switch (this.tag)
            {
                case "Slime":
                    playImpact("green");
                    break;
                case "Spike":
                    playImpact("green");
                    break;
                case "Fatblob":
                    playImpact("gold");
                    break;
                case "RedCell":
                    playImpact("red");
                    break;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            reduceHealth(20);
        //if (collision.gameObject.tag == "Corridor")
        //    Destroy(gameObject);
    }

    private void playImpact(string s)
    {
        GameObject x = null;
        for (int i = 0; i < 5; i++)
        {
            switch (s)
            {
                case "red":
                    x = collisionPrefabRed.transform.GetChild(i).gameObject;
                    break;
                case "green":
                    x = collisionPrefabGreen.transform.GetChild(i).gameObject;

                    break;
                case "gold":
                    x = collisionPrefabGold.transform.GetChild(i).gameObject;
                    break;
            }
            if (!x.activeSelf)
            {
                // randomly choose a spawning point and instantiate one of the monsters
                Vector3 position = transform.position;
                Quaternion rotation = transform.rotation;
                x.SetActive(true);
                x.transform.position = position;
                x.transform.rotation = rotation;
                break;
            }
        }

    }

}
