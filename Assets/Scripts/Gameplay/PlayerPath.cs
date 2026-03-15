using UnityEngine;
public class PlayerPath : MonoBehaviour
{
    private void Awake()
    {
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
