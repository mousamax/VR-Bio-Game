using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2_Instantiation : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousTime;
    private float currentTime;
    public int minX, maxX, minY, maxY, minZ, maxZ;
    public GameObject CO2;
    public int differenceTime;
    void Start()
    {
        previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime = Time.time;
        if (currentTime - previousTime >= differenceTime)
        {
            previousTime = Time.time;
            int x = Random.Range(minX, maxX);
            int y = Random.Range(minY, maxY);
            int z = Random.Range(minZ, maxZ);
            Vector3 position = new Vector3(x, y, z);
            GameObject instantCO2 = Instantiate(CO2);
            instantCO2.transform.position = position;
        }
    }
}
