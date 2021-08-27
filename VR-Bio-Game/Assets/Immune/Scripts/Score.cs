using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score=0;
    public void incrementScore (int amount)
    {
        score += amount;
        if (score < 0)
            score = 0;
    }
}
