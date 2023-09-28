using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetItem : MonoBehaviour , BaseItem
{
    public string Name { get ; set ; }
    public string Description { get ; set ; }
    public ITEM_TYPE Type { get ; set ; }
    public int Price { get ; set ; }
    public int DamageExtra { get ; set ; }
    public int LifeExtra { get ; set ; }


    private void Start()
    {
        Name = "Helmet";
        Description = "";
        Type = ITEM_TYPE.DEFENCE;
        Price = 0;
        DamageExtra = 0;
        LifeExtra = 30;
    }

}
