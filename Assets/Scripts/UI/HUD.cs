using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static PlayerControls;
using static UnityEngine.Rendering.DebugUI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image hiddenImage, dadEye;
    [SerializeField] private Color green, red,idle,warning,danger;
    private bool inVision;

    public static HUD instance;

    public enum CheckingState
    {
        Idle,
        Warning,
        Danger,
    }
    public void Idle()
    {
        eyeState = CheckingState.Idle;
    }
    public void Warning()
    {
        eyeState = CheckingState.Warning;
    }
    public void Danger()
    {
        eyeState = CheckingState.Danger;
    }
    [SerializeField] public CheckingState eyeState;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Idle();
    }
    private void Update()
    {
        switch (eyeState)
        {
            case CheckingState.Idle:
                dadEye.color = idle;
                idle.a = 1;
                break;
            case CheckingState.Warning:
                dadEye.color = warning;
                warning.a = Mathf.PingPong(Time.time*8,1);
                break;
            case CheckingState.Danger:
                dadEye.color = danger;
                danger.a = 1;
                break;
        }
        if (!Dad.instance.isPlayerHidden)
        {
            hiddenImage.color = red;
        }
        else
        {
            hiddenImage.color = green;
        }
    }
    
}
