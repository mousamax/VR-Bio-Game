using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Tutorial._Tutorial == null)
        {
            Tutorial._Tutorial = this.GetComponent<Tutorial>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
