using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingStateMachine : BaseGameStateMachine
{
    public override GAME_STATE_MACHINE GetStateType()
    {
        return GAME_STATE_MACHINE.PLAYINGSTATE;
    }

    public override void OnEnterState(GameStateMachineManager managerState)
    {
        
    }

    public override void OnExitState(GameStateMachineManager managerState)
    {
        
    }

    public override void UpdateState(GameStateMachineManager managerState)
    {
        
    }
}
