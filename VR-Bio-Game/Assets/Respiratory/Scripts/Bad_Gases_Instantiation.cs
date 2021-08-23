using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad_Gases_Instantiation : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousTime;
    private float currentTime;
    public int minX, maxX, minY, maxY, minZ, maxZ;
    public GameObject CO2;
    public GameObject N2;
    public int differenceTime;
    public int counter = 0;
    void Start()
    {
        previousTime = Time.time;
        Random.InitState(System.Environment.TickCount);
        Vector3 position = new Vector3((float) -15.5, 2, 62);
        GameObject g = Instantiate(N2);
        g.transform.position = position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime = Time.time;
        if (currentTime - previousTime >= differenceTime && counter < 50)
        {

            
            //previousTime = Time.time;
            //int x = Random.Range(minX, maxX);
            //int y = Random.Range(minY, maxY);
            //int z = Random.Range(minZ, maxZ);
            //Vector3 position = new Vector3(x, y, z);
            //if (counter % 2 == 0)
            //{
            //    GameObject instantCO2 = Instantiate(CO2);
            //    instantCO2.transform.position = position;
            //}
            //else
            //{
            //    GameObject instantN2 = Instantiate(N2);
            //    instantN2.transform.position = position;
            //}
            //counter++;
        }
    }
}
