using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N2_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousTime;
    private float currentTime;
    public float minX, maxX, minY, maxY, minZ, maxZ;
    public GameObject N2;
    public int differenceTime;
    public int N2counter = 0;
    public int maxN2 = 50;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime = Time.time;
        if (currentTime - previousTime >= differenceTime && N2counter < maxN2)
        {


            previousTime = Time.time;
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            float z = Random.Range(minZ, maxZ);
            Vector3 position = new Vector3(x, y, z);

            GameObject instantN2 = Instantiate(N2);
            instantN2.transform.position = position;

            N2counter++;
        }
    }
}
