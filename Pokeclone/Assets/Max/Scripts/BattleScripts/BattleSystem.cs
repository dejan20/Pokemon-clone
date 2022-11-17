using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    private void Start()
    {
        SetupBattle();
    }

    private void SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.spirit);
        enemyHud.SetData(enemyUnit.spirit);

        //StartCoroutine(dialogBox.TypeDialog($"A wild {playerUnit.spirit.Base.Name} appeared."));
        dialogBox.SetDialog("dit is een test");
    }
}
