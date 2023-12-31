using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ITEM_TYPE Type { get; set; }
    public int Price { get; set; }
    public int DamageExtra { get; set; }
    public int LifeExtra { get; set; }


}
