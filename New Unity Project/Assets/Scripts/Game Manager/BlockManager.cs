using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    #region Fields
    internal const float MAX_X_POSITION_SHIFT = 4.62f;
    internal const float MIN_X_POSITION_SHIFT = 1.67f;
    internal const float Y_POSITION = -1.47f;


    internal bool isEndOfRound = false;
    internal List<GameObject> uselessPlatforms;


    [SerializeField]
    private List<GameObject> platforms;
    [SerializeField]
    private Unit player;
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
    void Start()
    {
        uselessPlatforms = new List<GameObject>();
    }

    void Update()
    {
        if (platforms.Count > 0)
        {
            DeletePoces();
        }
        if (platforms.Count < 2 && !IsEndOfRound)
        {
            if (!player.HasPermissionToMove)
            {
                SpawnNewPlatform();
            }
        }
        if (IsEndOfRound)
        {
            DeleteAll();
        }
    }
    #endregion


    #region Private methods
    private void DeletePoces()
    {
        GameObject _firstPlatform = platforms[0];
        if (_firstPlatform.GetComponent<Platform>().IsUseless)
        {
            uselessPlatforms.Add(_firstPlatform);
            platforms.Remove(_firstPlatform);
        }
        DeleteUseless();
    }

    private void DeleteUseless()
    {
        if (uselessPlatforms.Count > 1)
        {
            GameObject _removablePlatform = uselessPlatforms[0];
            uselessPlatforms.Remove(_removablePlatform);
            Destroy(_removablePlatform);
        }
    }

    private void SpawnNewPlatform()
    {
        float _xPositionShift = platforms[0].transform.position.x
            + Random.Range(MIN_X_POSITION_SHIFT, MAX_X_POSITION_SHIFT);
        GameObject _newPlatform = Instantiate(platforms[0], new Vector3(_xPositionShift, Y_POSITION, 0), Quaternion.identity);
        _newPlatform.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 68f), 0);
        _newPlatform.GetComponent<Platform>().IsEnabledStopZone = false;
        platforms.Add(_newPlatform);
    }

    private void DeleteAll()
    {
        GameObject _removablePlatform;
        if (platforms.Count > 1)
        {
            _removablePlatform = platforms[0];
            platforms.Remove(_removablePlatform);
            Destroy(_removablePlatform);
        }
        else
        {
            GameObject _newPlatform = Instantiate(platforms[0], new Vector3(0, Y_POSITION, 0), Quaternion.identity);
            _newPlatform.GetComponent<Platform>().IsEnabledStopZone = true;
            platforms.Add(_newPlatform);
            _removablePlatform = platforms[0];
            platforms.Remove(_removablePlatform);
            Destroy(_removablePlatform);
            IsEndOfRound = false;
        }
        if (uselessPlatforms.Count > 0)
        {
            _removablePlatform = uselessPlatforms[0];
            uselessPlatforms.Remove(_removablePlatform);
            Destroy(_removablePlatform);
        }
    }
    #endregion
}
