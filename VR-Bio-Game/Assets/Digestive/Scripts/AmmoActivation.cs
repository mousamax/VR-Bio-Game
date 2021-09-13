using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoActivation : MonoBehaviour
{
    public Color ActivatedColor;
    public Color DeactivatedColor;
    private bool _activated = false;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collide with hcl");
        if (!_activated)
        {
            _activated = true;
            var m = this.GetComponent<Renderer>();
            if (m == null)
                Debug.Log("NULL!");
            if (m != null)
                m.material.color = ActivatedColor;
            
        }
    }
}
