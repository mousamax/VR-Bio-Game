using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellMoveScript : MonoBehaviour
{

    public float MaxZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        this.gameObject.transform.position += (this.gameObject.transform.forward.normalized / 4f);
        if ( this.gameObject.transform.position.z >= MaxZ )
        {
            Destroy(this.gameObject);
        }
    }

   
}
