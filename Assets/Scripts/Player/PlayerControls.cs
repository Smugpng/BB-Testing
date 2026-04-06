using System.Collections;
using System.Xml.Xsl;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    //Players Movement inputs
    public Vector2 moveInput;
    public bool isSprinting;

    //Pathwayhandeling
    private PlayerPath path;
    private Vector3 travelLocation;

    //Player Animatiors
    public Animator animator;
    public GameObject cat;
    

    //Player Stats
    [SerializeField][Range(0.1f,10f)] private float playerSpeed;
    [SerializeField][Range(0.1f, 10f)] private float sprintSpeed;
    [SerializeField] private float currSpeed;

    //Player State
    public enum MovementState 
    {
        Idle,
        Forward,
        Backward,
    }
    [SerializeField] public MovementState moveState;
    private void Awake()
    {
        path = GetComponentInParent<PlayerPath>();
        travelLocation = transform.position;
        currSpeed = playerSpeed;
    }
    private void Update() //Always moving towards target location
    {
        transform.position = Vector3.MoveTowards(transform.position, travelLocation, currSpeed * Time.deltaTime);
    }
    public void Movement(float xValue)
    {
        switch (xValue)
        {
            case -1:
                travelLocation = path.startPos.position;
                moveState = MovementState.Backward;
                animator.SetFloat("Speed", 1);

                cat.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
                break;
            case 0:
                moveState = MovementState.Idle;
                travelLocation = transform.position;
                animator.SetFloat("Speed", 0);
                break;
            case 1:
                travelLocation = path.endPos.position;
                moveState = MovementState.Forward;
                cat.transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
                animator.SetFloat("Speed", 1);
                break;
        }
    }
    public void walkSpeed(bool sprint)
    {
        if (sprint)
        {
            currSpeed =  + sprintSpeed;
            isSprinting = true;
        }
        else
        {
            currSpeed = playerSpeed;
            isSprinting = false;
        }
    }
    public void ResetState()
    {
        travelLocation = transform.position;
        currSpeed = playerSpeed;
    }
}
