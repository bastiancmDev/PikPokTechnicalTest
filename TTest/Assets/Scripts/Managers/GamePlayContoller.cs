using Assets.Scripts.StateMachine.Modalitys;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayContoller : MonoBehaviour
{
    // Start is called before the first frame update

    public int CurrentLevel;    
    public PlayerController PlayerControllerRef;
    public EnemyTemplate CurrentEnemy;
    public FigthModalityTemplate CurrentFigthModality;

    public bool IsTurnOfPlayer;

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


    public void InitGame()
    {
        var StateMachineGameObj = new GameObject();
        StateMachineGameObj.name = "StateMachine";
        StateMachineGameObj.AddComponent<GameStateMachineManager>();
        ManagerCentralizer.Instance.GameStateMachineManagerInstance = StateMachineGameObj.GetComponent<GameStateMachineManager>();
        PlayerControllerRef = FindAnyObjectByType<PlayerController>();
    }

    void Start()
    {
        InitGame();

        DontDestroyOnLoad(gameObject);
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

    public void ValidateIfEnemiesClose()
    {
        var enemies = FindObjectsOfType<MainEnemy>();
        foreach(var enemy in enemies)
        {
            if(Vector3.Distance(enemy.transform.position, PlayerControllerRef.transform.position) < 5)
            {
                CurrentEnemy = enemy;
                SetPlayingMode();
                return;
            }
        }        
    }

    public void SetPlayingMode()
    {
        CurrentFigthModality = new FigthModality();
        CurrentFigthModality.InitFigthModality(CurrentEnemy);
        ManagerCentralizer.Instance.UiMenuControllerInstance.ShowFigthUi();
    }
    public void ValidatePlayingMode()
    {
        IsTurnOfPlayer = true;
        //PrepareUiToPlayerTurn
    }
}
