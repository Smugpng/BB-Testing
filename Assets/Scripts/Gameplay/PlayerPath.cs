using System.IO;
using UnityEngine;
using static PlayerControls;
using static UnityEngine.Rendering.DebugUI;
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
        moveState = GameState.Looking;
        cookie.SetActive(true);
    }
    public Transform startPos, endPos;
    public GameObject player,cookie;
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPos.position, endPos.position);
    }
    private void Update()
    {
        switch (moveState)
        {
            case GameState.Looking:
                float distance = Vector3.Distance(player.transform.position, endPos.position);
                if (distance <= 0) GrabCookie();
                break;
            case GameState.Returning:
                float distance2 = Vector3.Distance(player.transform.position, startPos.position);
                if (distance2 <= 0 && !cookie.activeInHierarchy) EndGame();
                break;
            case GameState.Menu:

                break;
        }

        
    }
    public void GrabCookie()
    {
        moveState = GameState.Returning;
        cookie.SetActive(false);
    }
    public void EndGame()
    {
        Debug.LogAssertion("Game Won!");
        Invoke("HHAHA", 2);
        
    }
    public void HHAHA()
    {
        STARTGAME();
        PropPlacement.instance.ResetProps();
    }
    public enum GameState
    {
        Menu,
        Looking,
        Returning,
    }
    [SerializeField] public GameState moveState;
}
