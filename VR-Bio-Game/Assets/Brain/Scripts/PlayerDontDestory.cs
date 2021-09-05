using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDontDestory : MonoBehaviour
{
    public static GameObject _Player;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (_Player == null)
        {
            _Player = this.gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (_Player == null)
        {
            Debug.Log("Renew Player");
            _Player = this.gameObject;
        }
    }
}
