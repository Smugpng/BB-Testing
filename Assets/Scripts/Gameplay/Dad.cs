using System.IO;
using UnityEngine;

public class Dad : MonoBehaviour
{
    public LayerMask mask;
    public GameObject player;
    public bool isPlayerHidden;
    public static Dad instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void CheckPlayer(PlayerPath path)
    {
        if (!isPlayerHidden)
        {
            path.STARTGAME();
        }

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
