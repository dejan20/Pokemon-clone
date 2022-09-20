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

    public string Name {
        get { return name; }
    }

    public string Description {
        get { return description; }
    }

    public Sprite FrontSprite {
        get { return frontSprite; }
    }

    public Sprite BackSprite { 
        get { return backSprite; }
    }

    public SpiritType Type1 {
        get { return type1; }
    }

    public SpiritType Type2 {
        get { return type2; }
    }

    public int MaxHp {
        get { return maxHp; }
    }

    public int Attack {
        get { return attack; }
    }

    public int SpAttack {
        get { return spAttack; }
    }

    public int Defense {
        get { return spDefense; }
    }

    public int Speed {
        get { return speed; }
    }
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