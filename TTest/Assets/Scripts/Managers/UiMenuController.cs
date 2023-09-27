using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenuController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PrefabPlayingUi;
    public GameObject PrefabPausedUi;
    public GameObject ShopUi;
    

    public void InitMainViews()
    {

    }


    public void ShowFigthMenu(bool show)
    {
        if(show) {
            PrefabPlayingUi.SetActive(true);
        }
        else
        {
            PrefabPlayingUi.SetActive(false);
        }
    }

    public void ShowPausedUi(bool show)
    {
        if (show)
        {
            PrefabPausedUi.SetActive(true);
        }
        else
        {
            PrefabPausedUi.SetActive(false);
        }
    }


    public void ShowShopUi(bool show) 
    {  
        if (show) 
        {
            ShopUi.SetActive(true);
        }
        else
        {
            ShopUi.SetActive(false);
        }
    }
}
