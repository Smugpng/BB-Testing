using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Dad : MonoBehaviour
{
    public LayerMask mask;
    public GameObject player;
    public bool isPlayerHidden;
    public static Dad instance;

    public UnityEvent warning;
    public UnityEvent checking;
    public UnityEvent reset;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void CheckBuildUp()
    {
        warning.Invoke();
        //StartEyeFlashing
        TurntoPlayer();
        //After build up check player
    }
    private Transform currentLook;
    private void TurntoPlayer()
    {
        var targetPos = player.transform.position - transform.position;
        targetPos.y = transform.position.y;
        Quaternion lokRot = Quaternion.LookRotation(targetPos, Vector3.up);
        currentLook = transform;
        LeanTween.rotate(this.gameObject, lokRot.eulerAngles, 1.5f).setOnComplete(CheckPlayer);
    }
    public void CheckPlayer()
    {
        checking.Invoke();
        if (!isPlayerHidden)
        {
            PlayerPath.instance.STARTGAME();
            ReturnToNormalPlay();
            LeanTween.rotate(this.gameObject, new Vector3(0, -90, 0), .5f);
        }
        else
        {
            LeanTween.rotate(this.gameObject, new Vector3(0,-90,0), 1.5f).setOnComplete(ReturnToNormalPlay);
            //return to position and tell player stats to start counting again
        }
    }
    private void ReturnToNormalPlay()
    {
        reset.Invoke();
        PlayerStats.instance.ResetSus();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position, player.transform.position, out hit))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position, player.transform.position, Color.green, 2.5f);
                isPlayerHidden = false;
            }
            else
            {
                Debug.DrawLine(transform.position, hit.transform.position, Color.red, 2.5f);
                isPlayerHidden = true;
            }
        }
    }

}
