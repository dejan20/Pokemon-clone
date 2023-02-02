using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem2 : MonoBehaviour
{
    GameObject button;
    TextMeshProUGUI ButtonText;

    public int j;

    int earnedXP;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    GameObject enemy;
    [SerializeField] GameObject player;

    [SerializeField] private master master = new master();
    [SerializeField] GameObject character;
    [SerializeField] SpiritParty spiritParty = new SpiritParty();

    [SerializeField] GameObject spiritPrefabPlayer;
    [SerializeField] GameObject spiritPrefabEnemy;
    [SerializeField] GameObject randomSpirit;
    [SerializeField] private SpiritPartyUI spiritPartyUI;

    public bool randomSpiritBool = true;
    public int chosenSpirit = 0;

    public Canvas CanvasObject;

    GameObject partyUI;

    int randomSpiritInt;
    int i;

    [SerializeField] public GameObject spiritButton;
    [SerializeField] public GameObject fight;
    [SerializeField] public GameObject bag;
    [SerializeField] public GameObject flee;
    [SerializeField] public GameObject dialogueText;

    [SerializeField] public GameObject ActionSelector;
    [SerializeField] public GameObject spiritSelector;
    [SerializeField] public GameObject Back;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text Dialog;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    void Update()
    {
        if (playerUnit.isDead == true)
        {
            if (j >= spiritParty.spiritList.Count)
            {
                Dialog.text = "You lost!";

                partyUI.GetComponent<Canvas>().enabled = true;
                //master.transform.GetChild(spiritParty.selectedSpirit).gameObject.SetActive(false);
                SceneManager.LoadScene(5);
            }

            j++;

            playerPrefab = master.transform.GetChild(spiritParty.selectedSpirit).gameObject;
            spiritParty.spiritList[spiritParty.selectedSpirit] = playerPrefab;

            playerPrefab.SetActive(false);

            spiritParty.selectedSpirit++;

            playerPrefab = master.transform.GetChild(spiritParty.selectedSpirit).gameObject;
            playerPrefab.SetActive(true);
            try
            {
                spiritPrefabPlayer = spiritParty.spiritList[spiritParty.selectedSpirit];
                spiritPrefabPlayer = spiritParty.spiritList[spiritParty.selectedSpirit].gameObject;
            }
            catch (System.Exception)
            {
                spiritParty.selectedSpirit = -1;
                for (int i = 0; i <= 6; i++)
                {
                    spiritParty.selectedSpirit++;
                }
            }

            playerPrefab = spiritPrefabPlayer;

            GameObject playerGO = playerPrefab, playerBattleStation;
            playerUnit = playerGO.GetComponent<Unit>();

            playerHUD.SetHUD(playerUnit);
        }

        if (enemyUnit.isDead == true)
        {
            earnedXP = Random.Range(5, 10);
            playerUnit.unitCurrentXP += earnedXP;

            Won();

            partyUI.GetComponent<Canvas>().enabled = true;
            SceneManager.LoadScene(2);
        }
    }

    void Awake()
    {
        if (randomSpiritBool == true)
        {
            randomSpiritInt = Random.Range(0,8);
        }
        else if (randomSpiritBool == false)
        {
            randomSpiritInt = chosenSpirit;
        }

        spiritParty = GameObject.Find("character").GetComponent<SpiritParty>();
        spiritPrefabPlayer = spiritParty.spiritList[spiritParty.selectedSpirit];

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

        character = GameObject.Find("character");

        spiritPrefabPlayer = spiritParty.spiritList[spiritParty.selectedSpirit].gameObject;

        spiritPrefabEnemy = master.allSpiritList[randomSpiritInt].gameObject;
        spiritPrefabEnemy = Instantiate(spiritPrefabEnemy, new Vector3 (-311,4,90), Quaternion.identity);

        playerPrefab = spiritPrefabPlayer;
        enemyPrefab = spiritPrefabEnemy;

        playerPrefab.SetActive(true);

        GameObject playerGO = playerPrefab, playerBattleStation;
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGo = enemyPrefab, enemyBattleStation;
        enemyUnit = enemyGo.GetComponent<Unit>();

        Dialog.text = "A wild " + enemyUnit.unitName + " approaches.";

        partyUI.GetComponent<Canvas>().enabled = false;

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    int firstCalc;
    int secondCalc;

    IEnumerator PlayerAttack()
    {
        firstCalc = 2 * playerUnit.attack * playerUnit.spiritMoves[0].power;
        secondCalc = firstCalc / 50 + 2;

        Debug.Log(secondCalc / 8);
        return Attack(enemyUnit.TakeDamage(secondCalc / 8));
    }

    IEnumerator PlayerAttack2()
    {
        firstCalc = 2 * playerUnit.attack * playerUnit.spiritMoves[0].power;
        secondCalc = firstCalc / 50 + 2;

        Debug.Log(secondCalc / 8);
        return Attack(enemyUnit.TakeDamage(secondCalc / 8));
    }

    IEnumerator PlayerAttack3()
    {
        firstCalc = 2 * playerUnit.attack * playerUnit.spiritMoves[0].power;
        secondCalc = firstCalc / 50 + 2;

        Debug.Log(secondCalc / 8);
        return Attack(enemyUnit.TakeDamage(secondCalc / 8));
    }

    IEnumerator PlayerAttack4()
    {
        firstCalc = 2 * playerUnit.attack * playerUnit.spiritMoves[0].power;
        secondCalc = firstCalc / 50 + 2;

        Debug.Log(secondCalc / 8);
        return Attack(enemyUnit.TakeDamage(secondCalc / 8));
    }

    IEnumerator EnemyTurn()
    {
        Dialog.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        firstCalc = 2 * enemyUnit.attack * enemyUnit.spiritMoves[0].power;
        secondCalc = firstCalc / 50 + 2;

        Debug.Log(secondCalc / 8);

        bool isDead = playerUnit.TakeDamage(secondCalc / 8);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Dialog.text = "You win!";
            new WaitForSeconds(5f);
            partyUI.GetComponent<Canvas>().enabled = false;
            SceneManager.LoadScene(5);
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

    IEnumerator PlayerspiritCatch()
    {     
        Dialog.text = enemyUnit.unitName + " has been Catched!";

        spiritParty.spiritList.Add(master.allSpiritList[randomSpiritInt]);
        spiritPartyUI.SpiritPartyImages(i);
        spiritParty.selectedSpirit++;
        spiritPrefabPlayer = spiritParty.spiritList[spiritParty.selectedSpirit].gameObject;
        spiritPrefabPlayer = Instantiate(spiritPrefabPlayer, new Vector3 (-320,1,90), Quaternion.identity);
        spiritPrefabPlayer.transform.SetParent(master.transform);
        spiritParty.spiritList[spiritParty.selectedSpirit] = spiritPrefabPlayer;

        playerPrefab.SetActive(false);

        spiritPartyUI.SpiritPartyImages(SpiritParty.i);
        Debug.Log(SpiritParty.i);
        spiritParty.IPlus();             

        yield return new WaitForSeconds(2f);

        partyUI.GetComponent<Canvas>().enabled = true;
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
        spiritButton.SetActive(true);
        fight.SetActive(true);
        flee.SetActive(true);
        bag.SetActive(true);
        ActionSelector.SetActive(false);
        spiritSelector.SetActive(false);

        Dialog.text = "what do you do?";
    }

    public void OnspiritCatchButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerspiritCatch());
    }

    public void OnFleeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        partyUI.GetComponent<Canvas>().enabled = true;
        SceneManager.LoadScene(2);
        Debug.Log("Back to MainScene");
    }

    public void OnSwitchButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        
        /*spiritParty.selectedSpirit++;
        Destroy(playerPrefab);
        spiritPrefabPlayer = spiritParty.spiritList[spiritParty.selectedSpirit];
        spiritPrefabPlayer = spiritParty.spiritList[spiritParty.selectedSpirit].gameObject;
        spiritPrefabPlayer = Instantiate(spiritPrefabPlayer, new Vector3 (-320,1,90), Quaternion.identity);

        playerPrefab = spiritPrefabPlayer;

        GameObject playerGO = playerPrefab, playerBattleStation;
        playerUnit = playerGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);*/
    }

        public void OnBagButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        CanvasObject.GetComponent<Canvas>().enabled = true;
        
    }

    public void MoveUI()
    {
        fight.SetActive(false);
        flee.SetActive(false);
        bag.SetActive(false);
        dialogueText.SetActive(false);
        spiritButton.SetActive(false);

        ActionSelector.SetActive(true);
        dialogueText.SetActive(true);
        Dialog.text = "Choose your move:";
    }

    public void SelectUI()
    {
        fight.SetActive(false);
        flee.SetActive(false);
        bag.SetActive(false);
        dialogueText.SetActive(false);
        spiritButton.SetActive(false);

        spiritSelector.SetActive(true);
        dialogueText.SetActive(true);
        Dialog.text = "Choose your spirit:";
    }

    public IEnumerator Attack(bool isDead)
    {
        enemyHUD.SetHP(enemyUnit.currentHP);
        Dialog.text = playerUnit.unitName + " hit " + enemyUnit.unitName + " succesfully!";

        yield return new WaitForSeconds(2f);

        if (playerUnit.isDead)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator Won()
    {
        Dialog.text = "You Won!";
        yield return new WaitForSeconds(1f);
        Dialog.text = "You Gained " + earnedXP;
        yield return new WaitForSeconds(1f);
    }

    void Damage()
    {
        firstCalc = 2 * playerUnit.attack * playerUnit.spiritMoves[0].power;
        secondCalc = firstCalc / 50 + 2;

        Debug.Log(secondCalc / 8);
    }
}
