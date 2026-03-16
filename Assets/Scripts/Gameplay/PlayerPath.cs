using UnityEngine;
public class PlayerPath : MonoBehaviour
{
    public static PlayerPath instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        STARTGAME();
    }
    public void STARTGAME()
    {
        player.transform.position = startPos.position;
    }
    public Transform startPos, endPos;
    public GameObject player;
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPos.position, endPos.position);
    }
}
