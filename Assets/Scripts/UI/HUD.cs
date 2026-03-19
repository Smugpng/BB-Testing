using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static PlayerControls;
using static UnityEngine.Rendering.DebugUI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image hiddenImage, dadEye;
    [Header("Sus meter")]
    [SerializeField] private Color idle,warning,danger;
    [Header("Player hidden icon")]
    [SerializeField] private Color green,red;
    private float susLerp;

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
                float currentSus = PlayerStats.instance.LerpAmount();
                susLerp = Mathf.Lerp(susLerp, currentSus, Time.deltaTime * 2);
                dadEye.fillAmount = susLerp;
                break;
            case CheckingState.Warning:
                dadEye.color = warning;
                warning.a = Mathf.PingPong(Time.time* 8, 1);
                dadEye.fillAmount = 1;
                break;
            case CheckingState.Danger:
                dadEye.color = danger;
                danger.a = 1;
                dadEye.fillAmount = 1;
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
