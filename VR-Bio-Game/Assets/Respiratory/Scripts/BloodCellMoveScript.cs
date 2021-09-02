using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellMoveScript : MonoBehaviour
{



    // Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.position += (this.gameObject.transform.forward.normalized / 20f);
       
    }

   
}
