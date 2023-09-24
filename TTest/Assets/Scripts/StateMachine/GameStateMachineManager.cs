using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachineManager : MonoBehaviour
{
    // Start is called before the first frame update

    BaseGameStateMachine _currentState;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _currentState = new IdlStateMachine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(BaseGameStateMachine newState)
    {
        _currentState = newState;
        switch (_currentState) {
            case IdlStateMachine:
                break;
            case MovingStateMachine:
                break;
             case ShowingUIGameState:
                break;
        }
    }


    public GAME_STATE_MACHINE GetGameStateType()
    {
        return _currentState.GetStateType();
    }
}
