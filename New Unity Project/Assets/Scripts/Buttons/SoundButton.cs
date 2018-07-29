using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    #region Fields
    internal bool isOn;
    internal Image sprite;


    [SerializeField]
    private Sprite soundOn;
    [SerializeField]
    private Sprite soundOff;
    #endregion


    #region Properties
    public bool IsOn
    {
        get
        {
            return isOn;
        }
        set
        {
            isOn = value;
        }
    }
    #endregion



    #region Unity lifecycle
    void Start()
    {
        sprite = GetComponent<Image>();
        switch (PlayerPrefs.GetInt("Sound"))
        {
            case 1:
                IsOn = true;
                sprite.sprite = soundOn;
                break;
            case 2:
                IsOn = false;
                sprite.sprite = soundOff;
                break;
            default:
                PlayerPrefs.SetInt("Sound", 1);
                IsOn = true;
                break;
        }
    }


    void OnMouseDown()
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("Sound", 2);
            PlayerPrefs.Save();
            IsOn = false;
            sprite.sprite = soundOff;

        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.Save();
            IsOn = true;
            sprite.sprite = soundOn;
        }
    }
    #endregion
}
