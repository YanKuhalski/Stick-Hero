using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private BlockManager gameManagerScript;
    [SerializeField]
    private MainCamera cameraScript;
    [SerializeField]
    private Unit playerScript;
    [SerializeField]
    private Text scoreFiled;
    [SerializeField]
    private Text bestScoreFiled;
    [SerializeField]
    private Image soundButtonSprite;
    [SerializeField]
    private CircleCollider2D sounndButtonCollider;
    [SerializeField]
    private SoundManager soundManagerScript;
    [SerializeField]
    private BoxCollider2D clickAreaCollider;
    #endregion

    #region Unity lifecycle
    public void OnMouseDown()
    {
        soundManagerScript.enabled = false;
        clickAreaCollider.enabled = true;
        gameManagerScript.enabled = true;
        cameraScript.enabled = true;
        playerScript.enabled = true;
        scoreFiled.enabled = true;
        bestScoreFiled.enabled = false;
        GetComponent<Image>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        soundButtonSprite.enabled = false;
        sounndButtonCollider.enabled = false;
    }
    #endregion
}
