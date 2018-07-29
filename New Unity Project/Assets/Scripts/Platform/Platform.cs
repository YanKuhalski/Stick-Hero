using UnityEngine;

public class Platform : MonoBehaviour
{
    #region Fields
    internal bool isUseless = false;
    internal GameObject player;
    internal StickTransformation script;


    [SerializeField]
    private Flore flore;
    [SerializeField]
    private GameObject stick;
    [SerializeField]
    private SpriteRenderer redBlock;
    #endregion


    #region Properties
    public bool IsUseless
    {
        get
        {
            return isUseless;
        }
        set
        {
            isUseless = value;
        }
    }
    #endregion


    #region Unity lifecycle
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        script = stick.GetComponent<StickTransformation>();
    }


    void FixedUpdate()
    {

        if (transform.position.x > 0.5f)
        {
            redBlock.enabled = true;
        }
        if (!player.GetComponent<Unit>().HasPermissionToMove && flore.IsHeHere)
        {
            script.enabled = true;
            redBlock.enabled = false;
        }
        if (!script.isOnPlase)
        {
            player.GetComponent<Unit>().HasPermissionToMove = true;
            enabled = false;
            IsUseless = true;
        }
    }
    #endregion
}
