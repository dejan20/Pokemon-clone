using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField] public MoveBase[] spiritMoves = new MoveBase[4];
    [SerializeField] public SpiritPartyUI spiritPartyUI;
    [SerializeField] public SpiritParty spiritParty;

    public bool isDead;

    public string unitName;

    public SpriteRenderer spriteRenderer;

    public int unitLevel;
    public int unitCurrentXP;
    public int unitXpToNextlevel = 100;

    public bool evolutionCheck;
    public Sprite evolutionSprite;


    public int attack;

    public int maxHP;
    public int currentHP;

    void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spiritParty = GameObject.Find("character").GetComponent<SpiritParty>();
        spiritPartyUI = GameObject.Find("Spirit Inventory").GetComponent<SpiritPartyUI>();
    }

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

            attack += Random.Range(3,5);
            maxHP += Random.Range(3,5);
        }

        if (evolutionCheck = true)
        {
            if (unitLevel >= 10)
            {
                spriteRenderer.sprite = evolutionSprite;
                GetComponent<Image>().sprite = evolutionSprite;
                spiritPartyUI.SpiritPartyImages(spiritParty.selectedSpirit);
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
