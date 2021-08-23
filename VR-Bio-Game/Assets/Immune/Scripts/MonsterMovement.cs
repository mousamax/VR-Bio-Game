using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float m_Thurst = -1.5f;

    void Update()
    {
        this.transform.position += this.transform.forward * m_Thurst * Time.deltaTime;
    }
}
