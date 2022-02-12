using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool ShootInput, PauseInput;
        
    private TankControls _tankControls;
    
    private void Awake()
    {
        _tankControls = new TankControls();
            
        //Cursor.visible = false;
    }

    private void LateUpdate()
    {
        ResetButtons();
    }

    private void OnEnable()
    {
        if (_tankControls == null) return;

        GetButtonsDown();
                
        _tankControls.Enable();
    }

    private void OnDisable()
    {
        _tankControls.Disable();
    }

    private void GetButtonsDown()
    {
        _tankControls.Actions.Shoot.started += i => ShootInput = true;
        _tankControls.Actions.Pause.started += i => PauseInput = true;
    }

    private static void ResetButtons()
    {
        ShootInput = false;
        PauseInput = false;
    }
}