using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellsSpawnerScript : MonoBehaviour
{
    private float _previousTime;
    private float _currentTime;

    private const int _differenceTime = 5;

    public GameObject RedBloodCell;
    public GameObject LookAt;
    
    private void Start()
    {
        _previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
    }
    // Update is called once per frame
    void Update()
    {
        _currentTime = Time.time;

        if(_currentTime - _previousTime >= _differenceTime)
        {
            
            _previousTime = _currentTime;
            int rand = Random.Range(1, 4);
            for (int i = 0; i < rand; i++)
            {
                GameObject rbc = Instantiate(RedBloodCell);
                rbc.transform.position = new Vector3(5.18f + (i/2f), 6.5f + (i/2f ), -6.69f + (i * 2));
                rbc.transform.LookAt(LookAt.transform);
            }
        
        }
    }
}
