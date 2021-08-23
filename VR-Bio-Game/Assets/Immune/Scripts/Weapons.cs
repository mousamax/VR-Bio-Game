using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] bool selected;
    // Start is called before the first frame update
    void Start()
    {
        selected=false;
    }

    public void Select(bool isselected)
    {
        if (isselected ==true) {
            // Debug.Log("weapon is selected");
        }
        selected=isselected;
    }
    public bool isSelected()
    {
        return selected;
    }
}
