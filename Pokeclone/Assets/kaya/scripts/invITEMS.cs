using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType 
{
    battle,
    key,
    normal

}
public abstract class invITEMS : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    public string ItemName;
    public int ItemAmount;

    public int giveHpAmount;
    public int giveMpAmount;
    public int DmgAmount;
    
    [TextArea(10,15)]
    public string description;

}
