using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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
        ManagerCentralizer.Instance.GamePlayContollerInstance.ProccessClick( mousePosition);
    }


    private void Update()
    {

        Vector2 mousePosition = _inputActions.PlayerMove.MousePosition.ReadValue<Vector2>();
        
        var ray = Camera.main.ScreenPointToRay(new Vector3(mousePosition.x,mousePosition.y,Camera.main.nearClipPlane));
        if (Physics.Raycast(ray, out var hitInfo))
        {
            Debug.DrawRay(ray.origin, hitInfo.point);
        }
    }
}
