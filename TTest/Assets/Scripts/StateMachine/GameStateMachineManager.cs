using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _currentState.UpdateState(this);
    }

    public void SetGameState(BaseGameStateMachine newState)
    {
        _currentState.OnExitState(this);
        _currentState= newState;
        _currentState.UpdateState(this);        
    }


    public GAME_STATE_MACHINE GetGameStateType()
    {
        return _currentState.GetStateType();
    }

}
