using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
    // Start is called before the first frame update
     public Action<bool> ShowFightUIEvent { get;  set; }
    public void ShowFigthUi()
    {
        ShowFightUIEvent.Invoke(true);
    }

    public void HideFigthUi()
    {
        ShowFightUIEvent.Invoke(false);
    }

    UiMenuController()
    {

    }


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
