using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseItem
{
   public string Name { get; set; }
   public string Description { get; set; }
   public ITEM_TYPE Type { get; set; }

}
