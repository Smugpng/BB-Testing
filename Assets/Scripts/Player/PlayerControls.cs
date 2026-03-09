using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    //Players Movement inputs
    public Vector2 moveInput;

    //Pathwayhandeling
    private PlayerPath path;

    //Player Stats
    [SerializeField][Range(0.1f,10f)] private float playerSpeed;
    [SerializeField][Range(0.1f, 10f)] private float sprintMulti;

    //Player State
    public enum MovementState 
    {
        Idle,
        Forward,
        Backward,
    }
    [SerializeField] private MovementState moveState;
    private void Awake()
    {
        path = GetComponentInParent<PlayerPath>();
    }
    private void Update()
    {
        if(moveInput.x > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, path.endPos.position, playerSpeed * Time.deltaTime);
            moveState = MovementState.Forward;
        }
        else if(moveInput.x < 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, path.startPos.position, playerSpeed * Time.deltaTime);
            moveState = MovementState.Backward;
        }
        else
        {
            transform.position = transform.position;
            moveState = MovementState.Idle;
        }
    }

}
