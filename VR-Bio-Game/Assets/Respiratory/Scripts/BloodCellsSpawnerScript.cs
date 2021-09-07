using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellsSpawnerScript : MonoBehaviour
{
    private float _previousTime;
    private float _currentTime;

    public int _differenceTime = 2;

    public GameObject RedBloodCell;
    public GameObject CO2;
    public GameObject LookAt;
    public GameObject StartAt;
    public int maxBloodCells = 10;
    public int bloodCellsCounter = 0;
    public float offset = 0.4f;
    [SerializeField] Color32 DarkRed = new Color32(0x66, 0x0c, 0x0c, 255);
    private void Start()
    {
        _previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
    }
    // Update is called once per frame
    void Update()
    {
        _currentTime = Time.time;
        if (_currentTime - _previousTime >= _differenceTime && bloodCellsCounter < maxBloodCells)
        {

            int rand = Random.Range(1, 4);
            if (rand + bloodCellsCounter >= maxBloodCells)
                rand = maxBloodCells - bloodCellsCounter;
            for (int i = 0; i < rand; i++)
            {
                Vector3 position = StartAt.gameObject.transform.position;

                //position.x += (float)(i * (float)0.1);
                //position.y += (float)(i * (float)0.1) + (float)0.1;
                //position.z += (float)(i * (float)0.2) + (float)0.2;

                position.x += i + 1;
                position.y += i + 1;
                position.z += i + 1;


                GameObject rbc = Instantiate(RedBloodCell);
                rbc.transform.position = position;
                rbc.transform.LookAt(LookAt.transform);
                rbc.GetComponent<Renderer>().material.color = DarkRed;
                rbc.tag = "CarbonizedBlood";
                bloodCellsCounter++;

                Vector3 co2_pos = position;
                Vector3 co2_LookAt = LookAt.transform.position;
                co2_pos.y += (float)offset;
                co2_LookAt.y += (float)offset;
                GameObject co2 = Instantiate(CO2);
                co2.transform.position = co2_pos;
                co2.transform.LookAt(co2_LookAt);
            }

            _previousTime = Time.time;
        }
    }
}
