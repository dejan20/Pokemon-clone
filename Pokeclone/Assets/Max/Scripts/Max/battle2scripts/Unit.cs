using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public MoveBase[] spiritMoves = new MoveBase[4];

    public bool isDead;

    public string unitName;

    public int unitLevel;
    public int unitCurrentXP;
    public int unitXpToNextlevel = 100;

    public GameObject evolution;
    public bool evolutionCheck;

    public int damage;

    public int maxHP;
    [SerializeField] public int currentHP;

    void Update()
    {
        if (currentHP <= 0)
        {
            isDead = true;
        }

        if (unitCurrentXP >= unitXpToNextlevel) 
        {
            unitLevel++;
            unitCurrentXP -= unitXpToNextlevel;
            unitXpToNextlevel = (int)(unitXpToNextlevel * 1.2f);

            damage += 3;
            maxHP += 10;
        }

        if (evolutionCheck = true)
        {
            if (unitLevel => 10)
            {

            }
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
