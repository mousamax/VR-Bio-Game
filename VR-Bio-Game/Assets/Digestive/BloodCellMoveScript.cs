using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DigestiveSystem
{
    public class BloodCellMoveScript : MonoBehaviour
    {

        public float MaxZ;


        // Update is called once per frame
        private void Update()
        {
            this.gameObject.transform.position += (this.gameObject.transform.forward.normalized / 10f);
            if (this.gameObject.transform.position.z >= MaxZ)
            {
                this.gameObject.SetActive(false);
            }
        }


    }
}
