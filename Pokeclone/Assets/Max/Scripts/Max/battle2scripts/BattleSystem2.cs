using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem2 : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    GameObject enemy;
    GameObject player;

    [SerializeField] GameObject character;
    [SerializeField] PokemonParty pokemonParty = new PokemonParty();
    [SerializeField] GameObject spiritPrefab;

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

    void Awake(){

    pokemonParty = GameObject.Find("character").GetComponent<PokemonParty>();
    spiritPrefab = pokemonParty.spiritList[0];

    }
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        character = GameObject.Find("character");
        
        //pokemonParty = character;
        spiritPrefab = pokemonParty.spiritList[0].gameObject;
        spiritPrefab = Instantiate(spiritPrefab);

        enemy = GameObject.Find("enemy");
        enemyPrefab = enemy.transform.GetChild(0).gameObject;
        //player = GameObject.Find("player");
        //playerPrefab = player.transform.GetChild(0).gameObject;
        playerPrefab = spiritPrefab;


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
            new WaitForSeconds(5f);
            SceneManager.LoadScene(4);
            Debug.Log("Back to MainScene");
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

    public void OnFleeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        SceneManager.LoadScene(4);
        Debug.Log("Back to MainScene");
    }
}
