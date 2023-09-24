using UnityEngine;

public abstract class BaseGameStateMachine {

    private GAME_STATE_MACHINE _gameState;
    public abstract void OnEnterState(GameStateMachineManager managerState);
    public abstract void UpdateState(GameStateMachineManager managerState);
    public abstract void OnExitState(GameStateMachineManager managerState);

    public abstract GAME_STATE_MACHINE GetStateType();
    

}
