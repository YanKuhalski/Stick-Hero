using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    #region Fields
    internal BlockManager blockManager;
    internal Unit playerScript;
    internal ScoreManager scoreCounter;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Image restartField;
    [SerializeField]
    private Text finalScores;
    [SerializeField]
    private SpriteRenderer restartButtonIm;
    [SerializeField]
    private CircleCollider2D restartButtonCollider;
    [SerializeField]
    private RestartButton restartButton;
    #endregion


    #region Unity lifecycle
    void Start()
    {
        blockManager = GetComponent<BlockManager>();
        scoreCounter = GetComponent<ScoreManager>();
        playerScript = player.GetComponent<Unit>();
    }

    void FixedUpdate()
    {
        if (!playerScript.IsAlive)
        {
            restartField.enabled = true;
            finalScores.enabled = true;
            restartButtonIm.enabled = true;
            restartButtonCollider.enabled = true;
            if (restartButton.IsPressed)
            {
                blockManager.IsEndOfRound = true;
                player.transform.position = new Vector3(0, -0.15f, 0);
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                playerScript.IsAlive = true;
                scoreCounter.IsEndOfRound = true;
                restartButton.IsPressed = false;
            }
        }
        else
        {
            restartField.enabled = false;
            finalScores.enabled = false;
            restartButtonIm.enabled = false;
            restartButtonCollider.enabled = false;
        }
    }
    #endregion
}
