using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    bool selected;
    // Start is called before the first frame update
    void Start()
    {
        selected=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Select(bool isselected)
    {
        selected=isselected;
    }
    bool isSelected()
    {
        return selected;
    }
}
