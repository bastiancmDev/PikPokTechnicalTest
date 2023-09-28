using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats 
{
    PlayerInventoryHandler _playerInventoryHandler = new PlayerInventoryHandler();
    private int _damage;
    private int _health;
    private List<BaseItem> _equipedItems;
    public PlayerStats()
    {
        _equipedItems = new List<BaseItem>();
        SetBasedValues();
    }
    public int GetBaseDamage()
    {
        return _damage;
    }
    public int GetBaseHealth()
    {
        return _health;
    }
    public void SetBasedValues()
    {
        _damage = 10;
        _health = 100;
    }
    public void UpdateHealth(BaseItem Item)
    {

    }
    
    public int GetLifeInTurn()
    {
        int healthInTurn = _health;
        foreach (var item in _equipedItems)
        {
            if (item.Type == ITEM_TYPE.DEFENCE)
            {
                healthInTurn += item.LifeExtra;
                ProccesConsumableItem(item);
            }
        }
        //procces life
        return healthInTurn;
    }
    public void ProccesConsumableItem(BaseItem Item)
    {
    }

    public void DefenceMovement()
    {
        _health +=  20;
    }


    public void ReviceDamage(int damage)
    {
        _health -= damage;
    }

    public void ReciveItem(BaseItem Item)
    {
        _equipedItems.Add(Item);
        ProccessItem(Item);
        
    }

    public void ProccessItem(BaseItem Item)
    {
        switch(Item.Type)
        {
            case ITEM_TYPE.DEFENCE:
                _health += Item.LifeExtra;
                break;
            case ITEM_TYPE.OFFENSIVE:
                _damage += Item.DamageExtra;
                break;
        }
        ManagerCentralizer.Instance.UiMenuControllerInstance.UpdateFigthStats();
    }





}
