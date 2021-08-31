using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousTime;
    private float currentTime;
    public int minX, maxX, minY, maxY, minZ, maxZ;
    public GameObject O2;
    public int differenceTime;
    public int O2counter = 0;
    public int maxO2 = 50;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime = Time.time;
        if (currentTime - previousTime >= differenceTime && O2counter < maxO2)
        {


            previousTime = Time.time;
            int x = Random.Range(minX, maxX);
            int y = Random.Range(minY, maxY);
            int z = Random.Range(minZ, maxZ);
            Vector3 position = new Vector3(x, y, z);

            GameObject instantN2 = Instantiate(O2);
            instantN2.transform.position = position;

            O2counter++;
        }
    }
}
