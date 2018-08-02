using UnityEngine;

public class Flore : MonoBehaviour
{
    #region Fields
    internal bool heIsHere = false;
    internal bool isTouchedWithHead = false;
    #endregion


    #region Properties
    public bool IsHeHere
    {
        set
        {
            heIsHere = value;
        }
        get
        {
            return heIsHere;
        }
    }
    #endregion


    #region Unity lifecycle
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            heIsHere = true;
        }
        if (other.name == "Stick Head")
        {
            isTouchedWithHead = true;
        }
    }
    #endregion
}
