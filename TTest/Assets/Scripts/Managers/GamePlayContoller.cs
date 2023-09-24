using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayContoller : MonoBehaviour
{
    // Start is called before the first frame update

    public int CurrentLevel;    
    public PlayerController PlayerControllerRef;

    public void ProccessClick(Vector2 mousePosition)
    {
        if(ManagerCentralizer.Instance.GameStateMachineManagerInstance.GetGameStateType() == GAME_STATE_MACHINE.IDLSTATE)
        {
           if (ManagerCentralizer.Instance.TileMapControllerInstance.ValidatorMove(mousePosition))
            {
                MovePlayer(ManagerCentralizer.Instance.TileMapControllerInstance.GetPostionToMove(mousePosition));
            }
        }
        else
        {
            Debug.Log("Cant Move Player");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool CanMove()
    {
        return false;
    }


    public void MovePlayer(Vector3 mousePosition) {
        //SET STATE MACHINE TO MOVE PLAYER []
        PlayerControllerRef.MoveTo(mousePosition);
    }
}
