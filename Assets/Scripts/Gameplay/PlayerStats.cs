using System.IO;
using UnityEngine;
using static PlayerControls;
using static UnityEngine.Rendering.DebugUI;

public class PlayerStats : MonoBehaviour
{
    public float susMeter;
    [SerializeField]private PlayerControls pc;

    private void Awake()
    {
        pc = GetComponentInChildren<PlayerControls>();
    }
    private void Update() //Simple state check to simple suspicion meter
    {

        switch (pc.moveState)
        {
            case MovementState.Idle:
                susMeter += 0;
                return;
            case MovementState.Forward:
                susMeter += 1;
                break;
            case MovementState.Backward:
                susMeter += .5f;
                break;
        }
        if (pc.isSprinting)
        {
            susMeter += 2;
        }

    }
}
