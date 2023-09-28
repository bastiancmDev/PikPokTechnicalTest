using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanelUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOverPanel;
    public GameObject WinGamePanel;

    void Start()
    {
        ManagerCentralizer.Instance.UiMenuControllerInstance.ShowFinalPanelUIEvent += ShowFinalPanel;
    }



    public void ShowFinalPanel(bool winTheGame)
    {
        if(winTheGame)
        {
            WinGamePanel.SetActive(true);
        }
        else
        {
            GameOverPanel.SetActive(true);
        }
    }
}
