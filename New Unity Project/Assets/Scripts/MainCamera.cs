using UnityEngine;

public class MainCamera : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Unit player;
    #endregion


    #region Unity lifecycle
    void Update()
    {
        if (!player.HasPermissionToMove)
        {
            if (transform.position.x > player.transform.position.x + 2.25f)
            {
                transform.position -= new Vector3(0.5f, 0, 0);
            }
            if (transform.position.y > player.transform.position.y + 3.2)
            {
                transform.position -= new Vector3(0, 0.07f, 0);
            }
            else
            {
                if (transform.position.x < player.transform.position.x + 2.15)
                {
                    transform.position += new Vector3(0.07f, 0, 0);
                }
            }
        }
    }
    #endregion
}
