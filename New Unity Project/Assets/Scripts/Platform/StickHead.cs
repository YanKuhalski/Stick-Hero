﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickHead : MonoBehaviour
{
    #region Fields
    internal bool isOnFloor = false;
    internal bool isTouchedByPlayer = false;
    internal AudioSource audioSource;


    [SerializeField]
    private ScoreManager manager;
    #endregion


    #region Properties
    public bool IsOnFloor
    {
        set
        {
            isOnFloor = value;
        }
        get
        {
            return isOnFloor;
        }
    }


    public bool IsTouchedByPlayer
    {
        set
        {
            isTouchedByPlayer = value;
        }
        get
        {
            return isTouchedByPlayer;
        }
    }
    #endregion


    #region Unity lifecycle
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "RedBlock")
        {
            manager.UpScore();
        }
        if (other.tag == "Floor")
        {
            isOnFloor = true;
            manager.UpScore();
            if (audioSource.enabled)
            {
                audioSource.Play();
            }
        }
        if (other.tag == "Player")
        {
            IsTouchedByPlayer = true;
        }
    }
    #endregion
}
