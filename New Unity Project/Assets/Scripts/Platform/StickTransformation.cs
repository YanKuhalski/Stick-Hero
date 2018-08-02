using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickTransformation : MonoBehaviour
{
    #region Fields
    internal const float LENTH_GROW_SPEED = 0.1f;
    internal const int TURN_SPEED = 5;
    internal const int MAX_LENTH = 6;


    internal int turnDeg;
    internal float stickLenth;
    internal int finalTurnDeg = 90;
    internal bool isContinuesToTurn = true;
    internal bool transformationWasStoped = false;
    internal bool transformationWasStarted = false;
    internal AudioSource sound;
    internal Transform stickTransform;


    [SerializeField]
    private StickHead stickHead;
    [SerializeField]
    private ClickDetector clickArea;
    #endregion


    #region Properties
    public bool isOnPlase
    {
        set
        {
        }
        get
        {
            return isContinuesToTurn;
        }
    }
    #endregion


    #region Unity lifecycle
    void Start()
    {
        stickTransform = GetComponent<Transform>();
        sound = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        if (!transformationWasStoped)
        {
            if (!transformationWasStarted)
            {
                if (clickArea.IsDown)
                {
                    transformationWasStarted = true;
                    GetComponent<SpriteRenderer>().enabled = true;
                    if (sound.enabled)
                    {
                        sound.Play();
                    }
                }
            }
            if (transformationWasStarted)
            {
                if (clickArea.IsDown)
                {
                    stickTransform.localScale += new Vector3(0, LENTH_GROW_SPEED, 0);
                    stickLenth += LENTH_GROW_SPEED;
                    if (stickLenth >= MAX_LENTH)
                    {
                        transformationWasStoped = true;
                        sound.Pause();
                    }
                }
                else
                {
                    sound.Pause();
                    transformationWasStoped = true;
                }
            }
        }
        else
        {
            StartRotation();
        }
    }
    #endregion


    #region Private methods
    private void StartRotation()
    {
        if (turnDeg < finalTurnDeg)
        {
            turnDeg += TURN_SPEED;
            stickTransform.rotation = Quaternion.Euler(0, 0, -turnDeg);
        }
        else
        {
            isContinuesToTurn = false;
            if (!stickHead.IsOnFloor)
            {
                if (stickHead.IsTouchedByPlayer)
                {
                    finalTurnDeg = 180;
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
    #endregion
}
