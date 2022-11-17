using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHud : MonoBehaviour
{
    [SerializeField] public TMP_Text nameText;
    [SerializeField] public TMP_Text levelText;
    [SerializeField] HPBar hpBar;

    public void SetData(Spirits s)
    {
//        nameText.text = s.Base.Name;
//        levelText.text = "lvl." + s.Level;
 //       hpBar.SetHP((float) s.HP / s.MaxHP);
    }
}
