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
    [TextArea(15,20)]
    public string description;

}