using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    private string _currenScene;
    public string CurrenScene { get { return _currenScene; } }
    public void LoadNewScene(string sceneName, Action<Scene, LoadSceneMode> callback = null)
    {
        _currenScene = sceneName;
        SceneManager.LoadScene(sceneName);
        SceneManager.sceneLoaded += LoadedScene;
    }

    private void LoadedScene(Scene arg0, LoadSceneMode arg1)
    {
       switch (arg0.name)
        {
            
            case "MainMenu":
                break;
            default:
                ManagerCentralizer.Instance.InitGameplayController();
                ManagerCentralizer.Instance.InitTileMapController();
                break;
        }
    }

   

}
