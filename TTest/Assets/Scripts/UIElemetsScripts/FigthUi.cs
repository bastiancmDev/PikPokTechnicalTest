using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigthUi : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        ManagerCentralizer.Instance.UiMenuControllerInstance.ShowFightUIEvent += ShowThisPanel;
    }

    void Start()
    {
        ShowThisPanel(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtackEvent()
    {
        ManagerCentralizer.Instance.GamePlayContollerInstance.CurrentFigthModality.ProccesAttack();
    }

    public void DefenceEvent()
    {
        ManagerCentralizer.Instance.GamePlayContollerInstance.CurrentFigthModality.ProccesDefence();
    }


    public void ShowThisPanel(bool show)
    {
        gameObject.SetActive(show);
    }
}
