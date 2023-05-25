using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions inputActions;
    Vector2 Axes=>inputActions.GamePlay.Axis.ReadValue<Vector2>();
    public bool isJump => inputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool isStopJump => inputActions.GamePlay.Jump.WasReleasedThisFrame();
    public bool isMove=>Axes.x!=0;
    public float MoveX=>Axes.x;
    public float MoveY=>Axes.y;

    private void Awake() {
        inputActions=new PlayerInputActions();
    }
    public void EnableGamePlayInput(){
        inputActions.GamePlay.Enable();
    }
    public void DisableGamePlayInput(){
        inputActions.GamePlay.Disable();
    }

}
