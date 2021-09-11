using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    float m_Thurst = 4.0f;

    void Update()
    {
        this.transform.position += this.transform.forward * m_Thurst * Time.deltaTime;
    }
}
