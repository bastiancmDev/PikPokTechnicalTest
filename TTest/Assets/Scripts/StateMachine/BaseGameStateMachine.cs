using UnityEngine;

public abstract class BaseGameStateMachine {

    public abstract void OnEnterState(GameStateMachineManager managerState);
    public abstract void UpdateState(GameStateMachineManager managerState);
    public abstract void OnExitState(GameStateMachineManager managerState);

}
