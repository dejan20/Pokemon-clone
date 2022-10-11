using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    public void SetData(Spirits Spirits)
    {
        nameText.text = Spirits.Base.Name;
        levelText.text = "lvl" + Spirits.Level;
        hpBar.SetHP((float) Spirits.HP / Spirits.MaxHP);
    }
}
