using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private AudioSource bonus;
    [SerializeField]
    private AudioSource stick;
    [SerializeField]
    private AudioSource playerDeath;
    [SerializeField]
    private AudioSource stickHead;
    [SerializeField]
    private SoundButton soundButton;
    #endregion


    #region Unity lifecycle
    void Update()
    {
        if (soundButton.IsOn)
        {
            bonus.enabled = true;
            stick.enabled = true;
            playerDeath.enabled = true;
            stickHead.enabled = true;
        }
        else
        {
            bonus.enabled = false;
            stick.enabled = false;
            playerDeath.enabled = false;
            stickHead.enabled = false;
        }
    }
    #endregion
}
