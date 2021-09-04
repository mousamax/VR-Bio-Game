using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score=0;
    int playerHealth = 100;
    public void incrementScore (int amount)
    {
        //Debug.Log("Score is: " + score);
        score += amount;
        if (score < 0)
            score = 0;
    }
    public void reduceHealth(int amount)
    {
        playerHealth -= amount;
        if (playerHealth < 0)
            playerHealth = 0;
    }
}
