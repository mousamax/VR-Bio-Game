using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellsSpawnerScript : MonoBehaviour
{
    private float _previousTime;
    private float _currentTime;

    private const int _differenceTime = 5;
    private GameObject[] _redBloodCells;
    public GameObject RedBloodCell;
    public GameObject LookAt;
    public GameObject StartAt;


    private void Awake()
    {
        _redBloodCells = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            _redBloodCells[i] = Instantiate(RedBloodCell);
            _redBloodCells[i].SetActive(false);
        }
    }

    private void Start()
    {
        _previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);

    }

    // Update is called once per frame
    void Update()
    {
        _currentTime = Time.time;

        if (_currentTime - _previousTime >= _differenceTime)
        {

            _previousTime = _currentTime;
            int rand = Random.Range(1, 4);
            for (int i = 0; i < rand; i++)
            {
                Vector3 position = StartAt.gameObject.transform.position;
                position.x += (i / 2);
                position.y += (i / 2);
                position.z += (i * 2);

                _redBloodCells[i].transform.position = position;
                _redBloodCells[i].transform.LookAt(LookAt.transform);
                _redBloodCells[i].SetActive(true);
            }

        }
    }


}