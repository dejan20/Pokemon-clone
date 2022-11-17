using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Spirits/Create new move")]

public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea] 
    [SerializeField] string desription;

    [SerializeField] SpiritType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] public int PP;
}
