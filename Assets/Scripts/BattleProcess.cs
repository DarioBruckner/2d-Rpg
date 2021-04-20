using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, BATTLEPHASE, WON, LOST }
public enum PlayerStates { };

public class BattleProcess : MonoBehaviour {

    int playerActions = 0;
    int maxplayers = 4;

    public GameObject char1PreFab;
    public GameObject char2PreFab;
    public GameObject char3PreFab;
    public GameObject char4PreFab;

    public GameObject enemyPrefab;

    public Transform playerBattleStationChar1;
    public Transform playerBattleStationChar2;
    public Transform playerBattleStationChar3;
    public Transform playerBattleStationChar4;

    public Transform enemyBattleStation;

    Unit char1Unit;
    Unit char2Unit;
    Unit char3Unit;
    Unit char4Unit;

    Unit EnemyUnit;

    List<Unit> character = new List<Unit>();
    List<Unit> enemys = new List<Unit>();

    public TextMeshProUGUI char1Name;
    public TextMeshProUGUI char2Name;
    public TextMeshProUGUI char3Name;
    public TextMeshProUGUI char4Name;

    public TextMeshProUGUI EnemyName;

    public TextChanger textchanger;


    public BattleState state;

    // Start is called before the first frame update
    void Start() {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }


    IEnumerator SetupBattle() {

        GameObject char1GO = Instantiate(char1PreFab, playerBattleStationChar1);
        GameObject char2GO = Instantiate(char2PreFab, playerBattleStationChar2);
        GameObject char3GO = Instantiate(char3PreFab, playerBattleStationChar3);
        GameObject char4GO = Instantiate(char4PreFab, playerBattleStationChar4);


        char1Unit = char1GO.GetComponent<Unit>();
        char2Unit = char2GO.GetComponent<Unit>();
        char3Unit = char3GO.GetComponent<Unit>();
        char4Unit = char4GO.GetComponent<Unit>();



        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);

        EnemyUnit = enemyGO.GetComponent<Unit>();

        character.Add(char1Unit);
        character.Add(char2Unit);
        character.Add(char3Unit);
        character.Add(char4Unit);

        enemys.Add(EnemyUnit);

        foreach (Unit charaters in character) {
            
        }

        maxplayers = character.Count;

        char1Name.SetText(char1Unit.unitName);
        char2Name.SetText(char2Unit.unitName);
        char3Name.SetText(char3Unit.unitName);
        char4Name.SetText(char4Unit.unitName);

        EnemyName.SetText(EnemyUnit.unitName);

        textchanger.startupHealth(char1Unit.maxHealth, char2Unit.maxHealth, char3Unit.maxHealth, char4Unit.maxHealth, EnemyUnit.maxHealth);

        textchanger.setLog(EnemyUnit.unitName + " approches...");

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn() {
        
        textchanger.setLog(char1Unit.unitName + " choose an action: ");
       

    }

    
    void EnemyTurn() {
        
        EnemyUnit.action = 1;

        state = BattleState.BATTLEPHASE;        
        
    }

    IEnumerator BattlePhase() {





        yield return new WaitForSeconds(1);
    }

    public void OnAttackButton() {
        if (playerActions > maxplayers) {
            state = BattleState.ENEMYTURN;
            return;
        }
            

        if (state != BattleState.PLAYERTURN) {
            return;
        } else {
            character[playerActions].action = 1;
            playerActions++;       
        }
    }

    public void OnHealButton() {
        
        if (playerActions > maxplayers) {
            state = BattleState.ENEMYTURN;
            return;
        }


        if (state != BattleState.PLAYERTURN) {
            return;
        } else {
            character[playerActions].action = 1;
            playerActions++;
        }
    }

    IEnumerator PlayerAttack(Unit attackingUnit) {

        bool isDead = EnemyUnit.takeDamage(attackingUnit.Damage);
        textchanger.setEnemyHealth(EnemyUnit.currentHealth);

        textchanger.setLog(attackingUnit.unitName + " sucessfully hit");


        if (isDead) {
            state = BattleState.WON;
        }


        yield return new WaitForSeconds(2f);
    }

    IEnumerator PlayerHeal() {

        


        yield return new WaitForSeconds(2f);
    }

    void endBattle() {
        if(state == BattleState.WON) {
            textchanger.setLog("You won, well done");
        }else if (state == BattleState.LOST) {
            textchanger.setLog("Oh no you lost, try again!");
        }
    }

    void changeState() {

    }
}
