 using UnityEngine;

public class DieTerritory : MonoBehaviour
{
    #region Fields
    internal Transform dieTerritoryTransform;


    [SerializeField]
    private GameObject player;
    #endregion


    #region Unity lifecycle
    void Start()
    {
        dieTerritoryTransform = GetComponent<Transform>();
    }


    void Update()
    {
        dieTerritoryTransform.position = new Vector3(player.transform.position.x, -3, 0); ;
    }
    #endregion
}
