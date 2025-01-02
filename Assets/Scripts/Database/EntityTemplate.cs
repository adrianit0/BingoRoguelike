using System;
using Enums;
using UnityEngine;

[Serializable]
public class EntityTemplate {
    
    public TierEnum tier = TierEnum.Common;
    public String name;
    public String description;
    
    public bool canBeBoughtInstore = true;
    public bool canBeSoldInStore = true;
    public int storePrice = 0;
    public int sellPrice = 0;

    public GameObject prefab;

}
