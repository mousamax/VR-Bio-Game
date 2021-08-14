using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScript : MonoBehaviour
{
    public bool _isSplit = false;
    public GameObject CubePrefab;
    public Vector3 CubeScale;
    private void OnCollisionEnter(Collision collision)
    {
        if (!_isSplit)
        {
            this.gameObject.transform.localScale = CubeScale;
            GameObject cube = Instantiate(CubePrefab);
            cube.transform.localScale = CubeScale;
            cube.transform.position = this.gameObject.transform.position + cube.transform.localScale;
            ((SplitScript)cube.GetComponent("SplitScript"))._isSplit = true;
            _isSplit = true;
        }
        
    }

    
}
