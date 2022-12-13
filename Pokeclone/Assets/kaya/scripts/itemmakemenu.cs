using System.Collections;
using System.Collections.Generic;
using UnityEngine;









public enum typeitem
{
    heal,
    damage,
    key,
}
public abstract class itemmakemenu : ScriptableObject
{
    public GameObject prefab;
    public Sprite ItemImage;
    public typeitem type;
    [TextArea(15, 20)]
    public string decription;

}
