using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] SpiritsStats SpiritsStats;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Spirits spirit { get; set; }

    public void Setup()
    {
  //      spirit = new Spirits();
  //      if (isPlayerUnit)
  //          GetComponent<Image>().sprite = spirit.Base.BackSprite;
  //      else
 //           GetComponent<Image>().sprite = spirit.Base.FrontSprite;
    }
}
