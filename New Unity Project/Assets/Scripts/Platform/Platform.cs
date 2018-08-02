using UnityEngine;

public class Platform : MonoBehaviour
{
    #region Fields
    internal bool isUseless = false;
    internal bool isEnabledStopZone = true;
    internal Unit player;
    internal StickTransformation script;


    [SerializeField]
    private Flore flore;
    [SerializeField]
    private GameObject stick;
    [SerializeField]
    private SpriteRenderer redBlock;
    [SerializeField]
    private BoxCollider2D soptZone;
    [SerializeField]
    private BoxCollider2D stickCollider;
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


    public bool IsEnabledStopZone
    {
        get
        {
            return isEnabledStopZone;
        }
        set
        {
            isEnabledStopZone = value;
        }
    }
    #endregion


    #region Unity lifecycle
    void Start()
    {
        if (!isEnabledStopZone)
        {
            soptZone.enabled = false;
        }
        player = GameObject.FindWithTag("Player").GetComponent<Unit>();
        script = stick.GetComponent<StickTransformation>();
    }


    void FixedUpdate()
    {
        if (flore.isTouchedWithHead || isEnabledStopZone)
        {
            soptZone.enabled = true;
        }
        if (transform.position.x > 0.5f)
        {
            redBlock.enabled = true;
        }
        if (!player.HasPermissionToMove && flore.IsHeHere)
        {
            stickCollider.enabled = true;
            script.enabled = true;
            redBlock.enabled = false;
        }
        if (!script.isOnPlase)
        {
            player.HasPermissionToMove = true;
            enabled = false;
            IsUseless = true;
        }
    }
    #endregion
}
