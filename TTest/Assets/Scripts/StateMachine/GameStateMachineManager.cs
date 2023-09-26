using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateMachineManager : MonoBehaviour
{
    // Start is called before the first frame update

    BaseGameStateMachine _currentState;


    private IdlStateMachine _idlStateMachine;
    private MovingStateMachine _movingStateMachine;
    private ShowingUIGameState _showinUiStateMachine;
    private PlayingStateMachine _playingStateMachine;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _idlStateMachine = new IdlStateMachine();
        _movingStateMachine = new MovingStateMachine();
        _showinUiStateMachine = new ShowingUIGameState();
        _playingStateMachine = new PlayingStateMachine();
        _currentState = _idlStateMachine;
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
        _currentState.OnEnterState(this);        
    }


    public void EnterToNewState(GAME_STATE_MACHINE newState)
    {
        switch (newState)
        {
            case GAME_STATE_MACHINE.IDLSTATE:
                SetGameState(_idlStateMachine);
                break;
            case GAME_STATE_MACHINE.MOVINGPLAYER:
                SetGameState(_movingStateMachine);
                break;
            case GAME_STATE_MACHINE.SHOWINIU:
                SetGameState(_showinUiStateMachine);
                break;
            case GAME_STATE_MACHINE.PLAYINGSTATE:
                SetGameState(_playingStateMachine);
                break;
        }
    }


    public GAME_STATE_MACHINE GetGameStateType()
    {
        return _currentState.GetStateType();
    }

}
