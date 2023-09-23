using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerInputs _inputActions;

    private void Awake()
    {
        _inputActions = new PlayerInputs();
    }

    private void Start()
    {
        _inputActions.PlayerMove.MouseClick.performed += ProccesMouseClick;
    }

    

    private void OnEnable()
    {
        _inputActions.Enable();
    }



    // Update is called once per frame
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void ProccesMouseClick(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = _inputActions.PlayerMove.MousePosition.ReadValue<Vector2>();
        ManagerCentralizer.Instance.GamePlayContollerInstance.ProccessClick(mousePosition);
    }
}
