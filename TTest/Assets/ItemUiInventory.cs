using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUiInventory : MonoBehaviour
{
    public Button Bt;
    void Start()
    {
       Bt = GetComponent<Button>();
       Bt.onClick.AddListener(ClickItem);
    }


    public void ClickItem()
    {
        var mainInventory = FindObjectOfType<InvetoryUIHandler>();
        var ItemData = gameObject.GetComponent<BaseItem>();
        mainInventory.AddElementToUseElements(gameObject, ItemData);
        Bt.enabled = false;
    }

}
