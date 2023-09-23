using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitManagers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitManagers()
    {
        ManagerCentralizer.Instance.Init();
        var gameObject1 = GameObject.Find("SceneManager");
        var controller =  GameObject.FindAnyObjectByType<SceneController>();
        ManagerCentralizer.Instance.SceneControllerInstance = controller;
        ManagerConfiguration.Instance.Init();
        // When all Managers and load data are completed, call SceneManager to load main menu scene
        ManagerCentralizer.Instance.SceneControllerInstance.LoadNewScene("MainMenu");
    }
}
