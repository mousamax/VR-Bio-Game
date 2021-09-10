using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    float health;
    public GameObject collisionPrefabGreen;
    public GameObject collisionPrefabRed;
    public GameObject collisionPrefabGold;
    public GameObject Sword;
    public Score score;

    AudioSource swordAudioSource;
    public AudioClip coinClip;

    void Start()
    {
        resetHealth();
        swordAudioSource = Sword.GetComponent<AudioSource>();
    }

    public void reduceHealth(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            // Debug.Log("Monster is hit and health is reduced by: " + amount);
            killMonster(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (this.gameObject.tag == "FatBlob")
        //    Debug.Log("FatBLob Collided with tag: " + collision.gameObject.tag +" and layer"+ collision.gameObject.layer+ " With x:"+ this.transform.position.x+ " and with y:" + transform.position.y  + " and z:"+transform.position.z);
        if (collision.gameObject.tag == "External")
        {
            this.transform.position = new Vector3(-70, -70, -70);
            score.incrementScore(-5);
            score.reduceHealth(1);
            resetHealth();
            this.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player")
        {
            score.reduceHealth(10);
            resetHealth();
            killMonster(true);
        }
        else if (collision.gameObject.tag == "Bullet")
            reduceHealth(20);
        else if (collision.gameObject.tag == "Sword" && collision.gameObject.GetComponent<Weapons>().isSelected())
        {
            swordAudioSource.Play();
            reduceHealth(150);
        }
    }


    private void playImpact(string s)
    {
        GameObject collision = null;
        GetComponent<AudioSource>().PlayOneShot(coinClip);
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
                Vector3 position = transform.position;
                Quaternion rotation = transform.rotation;
                collision.SetActive(true);
                collision.transform.position = position;
                collision.transform.rotation = rotation;
                break;
            }
        }
    }

    private void killMonster(bool isPlayer)
    {
        if (isPlayer)
            score.incrementScore(-10);
        switch (this.tag)
        {
            case "Slime":
                if (!isPlayer)
                    score.incrementScore(20);
                playImpact("green");
                break;
            case "Spike":
                if (!isPlayer)
                    score.incrementScore(20);
                playImpact("green");
                break;
            case "FatBlob":
                if (!isPlayer)
                    score.incrementScore(50);
                playImpact("gold");
                break;
            case "RedCell":
                if (!isPlayer)
                    score.incrementScore(5);
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
