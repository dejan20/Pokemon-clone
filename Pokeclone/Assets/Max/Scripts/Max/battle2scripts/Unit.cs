using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public MoveBase[] spiritMoves = new MoveBase[4];

    public bool isDead;

    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    [SerializeField] public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {

        }
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
