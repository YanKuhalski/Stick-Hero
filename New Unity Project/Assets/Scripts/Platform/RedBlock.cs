using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : MonoBehaviour
{
    #region Fields
    internal AudioSource suound;
    #endregion


    #region Unity lifecycle
    void Start()
    {
        suound = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Stick Head")
        {
            if (suound.enabled)
            {
                suound.Play();
            }
        }
    }
    #endregion
}
