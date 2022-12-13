using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "defobj", menuName = "inv/items/default")]
public class itemgenerator : itemmakemenu
{
    public void Awake()
    {
        type = typeitem.heal;

    }

}
