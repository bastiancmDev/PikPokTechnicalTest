using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStateMachine : BaseGameStateMachine
{
    public override GAME_STATE_MACHINE GetStateType()
    {
        return GAME_STATE_MACHINE.MOVINGPLAYER;
    }

    public override void OnEnterState(GameStateMachineManager managerState)
    {
        throw new System.NotImplementedException();
    }

    public override void OnExitState(GameStateMachineManager managerState)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GameStateMachineManager managerState)
    {
        throw new System.NotImplementedException();
    }
}