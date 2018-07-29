 using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    #region Fields
    internal bool isDown;
    #endregion


    #region Properties
    public bool IsDown
    {
        set
        {
            isDown = value;
        }
        get
        {
            return isDown;
        }
    }
    #endregion


    #region Unity lifecycle
    void OnMouseDown()
    {
        isDown = true;
    }


    void OnMouseUp()
    {
        isDown = false;
    }
    #endregion
}
