using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class ItemBase : ScriptableObject
{
    public GameObject Object;
    
    public string ItemName;
    public int ItemAmount;

    public int giveHpAmount;
    public int giveMpAmount;
    public int DmgAmount;

    [TextArea(10, 15)]
    public string description;

}

