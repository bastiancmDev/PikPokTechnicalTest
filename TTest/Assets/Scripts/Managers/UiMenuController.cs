using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
    // Start is called before the first frame update

    public Action<bool> ShowFightUIEvent { get; set; }
    public Action<bool> ShowInventoryUIEvent { get; set; }


    public GameObject FigthUi;

   
    public void ShowFigthUI()
    {
        ShowFightUIEvent?.Invoke(true);
    }
    public void HideFigthUI()
    {
        ShowFightUIEvent?.Invoke(false);
    }
    public void ShowInventoryUI()
    {
        ShowInventoryUIEvent?.Invoke(true);
    }
    public void HideInventoryUI()
    {
        ShowInventoryUIEvent?.Invoke(false);
    }

}
