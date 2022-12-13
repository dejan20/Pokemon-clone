using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem2 : MonoBehaviour
{
    GameObject button;
    TextMeshProUGUI ButtonText;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    GameObject enemy;
    GameObject player;

    [SerializeField] private master master = new master();
    [SerializeField] GameObject character;
    [SerializeField] SpiritParty spiritParty = new SpiritParty();

    [SerializeField] GameObject spiritPrefabPlayer;
    [SerializeField] GameObject spiritPrefabEnemy;
    [SerializeField] GameObject randomSpirit;
    [SerializeField] private SpiritPartyUI spiritPartyUI;

    GameObject partyUI;

    int randomSpiritInt;
    int i;


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

    void Awake()
    {
        randomSpiritInt = Random.Range(0,3);

        spiritParty = GameObject.Find("character").GetComponent<SpiritParty>();
        spiritPrefabPlayer = spiritParty.spiritList[0];

        partyUI = GameObject.Find("Spirit Inventory");
        spiritPartyUI = GameObject.Find("Spirit Inventory").GetComponent<SpiritPartyUI>();

        master = GameObject.Find("master").GetComponent<master>();
        spiritPrefabEnemy = master.allSpiritList[randomSpiritInt];
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        state = BattleState.START;
        StartCoroutine(SetupBattle());

    }

    IEnumerator SetupBattle()
    {
        partyUI.SetActive(false);

        character = GameObject.Find("character");
        
        spiritPrefabPlayer = spiritParty.spiritList[0].gameObject;
        spiritPrefabPlayer = Instantiate(spiritPrefabPlayer, new Vector3 (-320,1,90), Quaternion.identity);

        spiritPrefabEnemy = master.allSpiritList[randomSpiritInt].gameObject;
        spiritPrefabEnemy = Instantiate(spiritPrefabEnemy, new Vector3 (-311,4,90), Quaternion.identity);

        playerPrefab = spiritPrefabPlayer;
        enemyPrefab = spiritPrefabEnemy;


        GameObject playerGO = playerPrefab, playerBattleStation;
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGo = enemyPrefab, enemyBattleStation;
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
        Debug.Log("Attack 1");
        return Attack(enemyUnit.TakeDamage(playerUnit.damage * playerUnit.spiritMoves[0].power));
    }

    IEnumerator PlayerAttack2()
    {
        Debug.Log("Attack 2");
        return Attack(enemyUnit.TakeDamage(playerUnit.damage * playerUnit.spiritMoves[1].power));
    }

    IEnumerator PlayerAttack3()
    {
        Debug.Log("Attack 3");
        return Attack(enemyUnit.TakeDamage(playerUnit.damage * playerUnit.spiritMoves[2].power));
    }

    IEnumerator PlayerAttack4()
    {
        Debug.Log("Attack 4");
        return Attack(enemyUnit.TakeDamage(playerUnit.damage * playerUnit.spiritMoves[3].power));
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
            partyUI.SetActive(false);
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

    IEnumerator PlayerCatch()
    {     
        Dialog.text = enemyUnit.unitName + " has been catched!";



        spiritParty.spiritList.Add(master.allSpiritList[randomSpiritInt]);

        spiritPartyUI.SpiritPartyImages(SpiritParty.i);
        Debug.Log(SpiritParty.i);
        spiritParty.IPlus();             

        yield return new WaitForSeconds(2f);

        partyUI.SetActive(true);
        SceneManager.LoadScene(5);
    }

    public void OnMove1Button()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

        MoveUI();
    }
    public void OnMove2Button()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack2());

        MoveUI();
    }
    public void OnMove3Button()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack3());

        MoveUI();
    }
    public void OnMove4Button()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack4());

        MoveUI();
    }

    public void OnAttackButton()
    {
        MoveUI();

        button = GameObject.Find("Move 1");
        ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
        ButtonText.text = playerUnit.spiritMoves[0].name;

        button = GameObject.Find("Move 2");
        ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
        ButtonText.text = playerUnit.spiritMoves[1].name;

        button = GameObject.Find("Move 3");
        ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
        ButtonText.text = playerUnit.spiritMoves[2].name;

        button = GameObject.Find("Move 4");
        ButtonText = button.GetComponentInChildren<TextMeshProUGUI>();
        ButtonText.text = playerUnit.spiritMoves[3].name;
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

    public void OnCatchButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerCatch());
    }

    public void OnFleeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        SceneManager.LoadScene(4);
        Debug.Log("Back to MainScene");
    }

    public void MoveUI()
    {
        heal.SetActive(false);
        fight.SetActive(false);
        flee.SetActive(false);
        bag.SetActive(false);
        dialogueText.SetActive(false);

        ActionSelector.SetActive(true);
        dialogueText.SetActive(true);
        Dialog.text = "Choose your move:";
    }

    public IEnumerator Attack(bool isDead)
    {
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
}
