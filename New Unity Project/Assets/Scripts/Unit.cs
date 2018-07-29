using UnityEngine;


public class Unit : MonoBehaviour
{
    #region Fields
    internal const float MOVING_SPEED = 0.05f;
    internal const float MIN_Y_POSITION = -0.172f;
    internal const float MAX_Y_POSITION = -0.165f;


    internal bool hasPermissionToMove = true;
    internal bool isAlive = true;
    internal Rigidbody2D body;
    internal AudioSource sound;
    #endregion


    #region Properties
    public bool HasPermissionToMove
    {
        get
        {
            return hasPermissionToMove;
        }
        set
        {
            hasPermissionToMove = value;
        }
    }


    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
        set
        {
            isAlive = value;
        }
    }
    #endregion


    #region Unity lifecycle
    void Start()
    {
        sound = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (IsAlive)
        {
            body.simulated = true;
            if (hasPermissionToMove)
            {
                Mooving();
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Stop Point")
        {
            HasPermissionToMove = false;
        }
        if (other.name == "Die Territory")
        {
            Die();
        }
    }
    #endregion


    #region Private methods
    private void Mooving()
    {
        if (transform.position.y < MAX_Y_POSITION && transform.position.y > MIN_Y_POSITION) ///// FIXE!!!!  FIXE!!!!  FIXE!!!!  FIXE!!!! 
        {
            transform.position += new Vector3(MOVING_SPEED, 0, 0);
        }
    }


    private void Die()
    {
        IsAlive = false;
        body.simulated = false;
        if (sound.enabled)
        {
            sound.Play();
        }
    }
    #endregion
}
