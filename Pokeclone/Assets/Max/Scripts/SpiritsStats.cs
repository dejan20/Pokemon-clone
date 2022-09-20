using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spirits", menuName = "Spirits/Create new spirit")]
public class SpiritsStats : ScriptableObject 
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] SpiritType type1;
    [SerializeField] SpiritType type2;

    //Base stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;
}


public enum SpiritType
{
    None,
    Fire,
    Ice,
    Wind,
    Lightning,
    Flying,
    Poison,
    Psychic,
    Fighting,
    Water
}