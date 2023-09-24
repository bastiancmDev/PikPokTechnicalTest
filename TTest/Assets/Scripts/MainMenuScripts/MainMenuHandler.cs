using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public void LoadNewGame()
    {
        ManagerCentralizer.Instance.SceneControllerInstance.LoadNewScene("LevelOne");
    }
}
