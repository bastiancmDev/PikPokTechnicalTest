using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCentralizer {
    #region Singleton
    private static ManagerCentralizer _instance;


    //ManagersReferences
    public SceneController SceneControllerInstance;
    public TileMapController TileMapControllerInstance;
    public PlayerController PlayerControllerInstance;
    public GamePlayContoller GamePlayContollerInstance;
    public GameStateMachineManager GameStateMachineManagerInstance;

    

    public static ManagerCentralizer Instance
    {
        get
        {
            if (_instance == null) _instance = new ManagerCentralizer();
            return _instance;
        }
    }

    public ManagerCentralizer()
    {
        Init();
    }

    public void DebugInstance()
    {
        Debug.Log(Instance.ToString());
    }

    public void Init()
    {
        //throw new NotImplementedException();
    }

    public void InitGameplayController()
    {
        if(GamePlayContollerInstance == null)
        {
            var gamePlayerControllerObj = new GameObject();
            gamePlayerControllerObj.name = "GamePlayController";
            gamePlayerControllerObj.AddComponent<GamePlayContoller>();
            GamePlayContollerInstance = gamePlayerControllerObj.GetComponent<GamePlayContoller>();  
        }
       
    }

    public void InitTileMapController()
    {
        if (TileMapControllerInstance == null)
        {
            var tileMapController = new GameObject();
            tileMapController.name = "TileMapController";
            tileMapController.AddComponent<TileMapController>();
            TileMapControllerInstance = tileMapController.GetComponent<TileMapController>();
        }

    }

    #endregion
}
