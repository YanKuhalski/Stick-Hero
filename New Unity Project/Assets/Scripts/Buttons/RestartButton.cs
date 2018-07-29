using UnityEngine;

public class RestartButton : MonoBehaviour
{
    #region Fields
    internal static bool isPressed = false;
    #endregion


    #region Properties
    public bool IsPressed
    {
        get
        {
            return isPressed;
        }
        set
        {
            isPressed = value;
        }
    }
    #endregion


    #region Unity lifecycle
    void OnMouseDown()
    {
        IsPressed = true;
    }
    #endregion 
}
