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
    public GameObject collisoinPrefabGold;

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
        if (transform.position.z <= -100)
            Destroy(this.gameObject);
    }

    public void reduceHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            switch (this.tag)
            {
                case "Slime":
                    Instantiate(collisionPrefabGreen, this.transform.position, this.transform.rotation);
                    break;
                case "Spike":
                    Instantiate(collisionPrefabGreen, this.transform.position, this.transform.rotation);
                    break;
                case "Fatblob":
                    Instantiate(collisoinPrefabGold, this.transform.position, this.transform.rotation);
                    break;
                case "RedCell":
                    Instantiate(collisionPrefabRed, this.transform.position, this.transform.rotation);
                    break;
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            reduceHealth(20);
    }

}
