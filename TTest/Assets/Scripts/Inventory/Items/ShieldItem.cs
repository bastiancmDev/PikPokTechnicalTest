using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : MonoBehaviour , BaseItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ITEM_TYPE Type { get; set; }
    public int Price { get; set; }
    public int DamageExtra { get; set; }
    public int LifeExtra { get; set; }


    private void Start()
    {
        Name = "Shield";
        Description = "";
        Type = ITEM_TYPE.DEFENCE;
        Price = 0;
        DamageExtra = 0;
        LifeExtra = 11;
    }
}
