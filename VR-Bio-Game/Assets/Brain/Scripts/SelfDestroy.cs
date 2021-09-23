using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float WaitTime = 1;

    void Awake()
    {
        Invoke("SelfDestruction", WaitTime);
    }

    void SelfDestruction()
    {
        Destroy(this.gameObject);
    }
}
