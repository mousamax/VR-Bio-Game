using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Slime" || other.gameObject.tag == "Spike" || other.gameObject.tag == "FatBlob" || other.gameObject.tag == "RedCell")
        {
            score -= 10;
            Debug.Log(score);
        }


    }
}
