using System.IO;
using UnityEngine;
using static PlayerControls;
using static UnityEngine.Rendering.DebugUI;

public class PlayerStats : MonoBehaviour
{
    //Suspicion meter and when to check
    public float susMeter,susMeterMax;

    //Dad contorls
    [SerializeField] private bool isChecking;

    //Player Data
    private float cookieMultiplier = 1f;
    //Other Scripts + this one
    [SerializeField] private PlayerControls pc;
    public static PlayerStats instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = new PlayerStats();
        }
        pc = GetComponentInChildren<PlayerControls>();
        InvokeRepeating("SusMeter", .1f, .5f);
    }
    public void resetData()
    {
        susMeter = 0f;
        cookieMultiplier = 1f;
        isChecking = false;
    }
    public void CookiePickup() { cookieMultiplier = 2f; } //When player picks up cookie and heads back make it harder to get to the end?
 
    public void SusMeter()
    {
        if(susMeter <= susMeterMax && !isChecking)
        {
            switch (pc.moveState)
            {
                case MovementState.Idle:
                    susMeter += 0;
                    return;
                case MovementState.Forward:
                    susMeter += (1* cookieMultiplier);
                    break;
                case MovementState.Backward:
                    susMeter += (.5f * cookieMultiplier);
                    break;
            }
            if (pc.isSprinting)
            {
                susMeter += (2 * cookieMultiplier);
            }
        }
        else if(isChecking)
        {
            return;
        }
        else
        {
            CheckSus();
        }
        
    }
    public void ResetSus()
    {
        isChecking = false;
    }
    public void CheckSus()
    {
        susMeter = 0;
        isChecking = true;
        Debug.Log("LOOKING!");
        Invoke("ResetSus",5f);
    }
}
