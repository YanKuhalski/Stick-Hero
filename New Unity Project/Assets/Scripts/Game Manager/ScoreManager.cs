using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Fields
    internal int score = 0;
    internal bool isEndOfRound = false;


    [SerializeField]
    private Text scoreCounter;
    [SerializeField]
    private Text bestScores;
    [SerializeField]
    private Text finalScores;
    #endregion


    #region Properties
    public bool IsEndOfRound
    {
        get
        {
            return isEndOfRound;
        }
        set
        {
            isEndOfRound = value;
        }
    }
    #endregion


    #region Unity lifecycle
    void Update()
    {
        string _bestResult;
        scoreCounter.text = score.ToString();
        _bestResult = PlayerPrefs.GetInt("Best").ToString();
        if (_bestResult == "")
        {
            _bestResult = "0";
        }
        bestScores.text = "Best result : " + _bestResult;
        if (IsEndOfRound)
        {
            int best = PlayerPrefs.GetInt("Best");
            if (score > best)
            {
                PlayerPrefs.SetInt("Best", score);
                PlayerPrefs.Save();
            }
            score = 0;
            isEndOfRound = false;
        }
        finalScores.text = "Your scores : " + score.ToString() + "\n\n" +
        "Previous best \n result : " + PlayerPrefs.GetInt("Best").ToString();
    }
    #endregion


    #region Public methods
    public void UpScore()
    {
        score++;
    }
    #endregion
}
