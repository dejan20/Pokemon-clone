using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem2 : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    [SerializeField] public GameObject heal;
    [SerializeField] public GameObject fight;
    [SerializeField] public GameObject bag;
    [SerializeField] public GameObject flee;
    [SerializeField] public GameObject dialogueText;

    [SerializeField] public GameObject ActionSelector;
    [SerializeField] public GameObject Back;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text Dialog;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        Dialog.text = "A wild " + enemyUnit.unitName + " approaches.";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        Dialog.text = playerUnit.unitName + " hit " + enemyUnit.unitName + " succesfully!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        Dialog.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Dialog.text = "You win!";
        }
        else if (state == BattleState.LOST)
        {
            Dialog.text = enemyUnit.unitName + " has defeated " + playerUnit.unitName + "!";
        }
    }

    void PlayerTurn()
    {
        Dialog.text = "what do you do? ";
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        Dialog.text = playerUnit.unitName + " feels a lot better!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

        heal.SetActive(false);
        fight.SetActive(false);
        flee.SetActive(false);
        bag.SetActive(false);
        dialogueText.SetActive(false);

        ActionSelector.SetActive(true);
        dialogueText.SetActive(true);
        Dialog.text = "Choose your move:";
    }

    public void OnBackButton()
    {
        heal.SetActive(true);
        fight.SetActive(true);
        flee.SetActive(true);
        bag.SetActive(true);
        ActionSelector.SetActive(false);

        Dialog.text = "what do you do?";
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}
