using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvetoryUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _bagItems;
    [SerializeField]
    private GameObject _itemsInUse;
    [SerializeField]
    private GameObject _panelInventory;
    void Start()
    {
        
    }

    // Update is called once per frame
   
    public void OpenInvetory(bool show)
    {
        _panelInventory.SetActive(show);
    }


    public void AddElementToUseElements(GameObject item, BaseItem itemData)
    {
        item.transform.parent = _itemsInUse.transform;
        ManagerCentralizer.Instance.GamePlayContollerInstance.PlayerControllerRef.GetPlayerStats().ReciveItem(itemData);
    }
}
