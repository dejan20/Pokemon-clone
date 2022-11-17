using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New defualt Item", menuName =" Inventory System/Items/Normal" )]
public class Normalitems : invITEMS
{
    public void Awake()
    {
        type = ItemType.normal;
        
    }

}
