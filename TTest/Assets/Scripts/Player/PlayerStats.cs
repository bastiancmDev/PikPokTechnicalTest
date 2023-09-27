using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats 
{
    PlayerInventoryHandler _playerInventoryHandler = new PlayerInventoryHandler();
    private int _damage;
    private int _health;
    private List<IItem> _bagItems;
    private List<IItem> _equipedItems;
    public PlayerStats()
    {
        _bagItems = new List<IItem>();
        _equipedItems = new List<IItem>();
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
    public void UpdateHealth(IItem Item)
    {

    }
    public int GetDamageInTurn()
    {
        int damageInTurn = _damage;
        foreach (var item in _equipedItems)
        {
            if (item.Type == ITEM_TYPE.OFFENSIVE)
            {
                damageInTurn += item.Damage;
                ProccesConsumableItem(item);
            }
        }
        //procces Damage
        return damageInTurn;
    }
    public int GetLifeInTurn()
    {
        int healthInTurn = _health;
        foreach (var item in _equipedItems)
        {
            if (item.Type == ITEM_TYPE.DEFENCE)
            {
                healthInTurn += item.Health;
                ProccesConsumableItem(item);
            }
        }
        //procces life
        return healthInTurn;
    }
    public void ProccesConsumableItem(IItem Item)
    {
    }


}
