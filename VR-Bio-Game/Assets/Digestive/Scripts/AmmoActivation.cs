using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigestiveSystem
{
    public class AmmoActivation : MonoBehaviour
    {
        public Color ActivatedColor;
        public Color DeactivatedColor;
        public bool activated = false;

        private void Update()
        {
            if (activated)
                this.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = ActivatedColor;
            else
                this.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = DeactivatedColor;
        }

        private void OnParticleCollision(GameObject other)
        {
            Debug.Log("collide with hcl");
            if (!activated)
            {
                activated = true;
                var m = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();
                if (m == null)
                    Debug.Log("NULL!");
                if (m != null)
                    m.material.color = ActivatedColor;

            }
        }
    }
}
