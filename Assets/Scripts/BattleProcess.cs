using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN,ENEMYTURN, BATTLEPHASE, WON, LOST }
public enum PlayerStates { };

public class BattleProcess : MonoBehaviour {

    

    public GameObject charMagePrefab;
    public GameObject charWarriorPrefab;
    public GameObject charPriestPrefab;
    public GameObject charThiefPrefab;

    public GameObject enemyPrefab;

    public Transform playerBattleStationChar1;
    public Transform playerBattleStationChar2;
    public Transform playerBattleStationChar3;
    public Transform playerBattleStationChar4;

    public Transform enemyBattleStation;

    List<CharacterClass> characters;

    Mage charMage;
    Warrior charWarrior;
    Priest charPriest;
    Thief charThief;

    Unit EnemyUnit;

    Queue<CharacterClass> playTurns;


    public TextMeshProUGUI charMageName;
    public TextMeshProUGUI charWarriorName;
    public TextMeshProUGUI charPriestName;
    public TextMeshProUGUI charThiefName;

    public TextMeshProUGUI EnemyName;

    public TextChanger textchanger;


    public BattleState state;

    // Start is called before the first frame update
    void Start() {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }


    IEnumerator SetupBattle() {

        GameObject charMageGO = Instantiate(charMagePrefab, playerBattleStationChar1);
        GameObject charWarriorGO = Instantiate(charWarriorPrefab, playerBattleStationChar2);
        GameObject charPriestGO = Instantiate(charPriestPrefab, playerBattleStationChar3);
        GameObject charThiefGO = Instantiate(charThiefPrefab, playerBattleStationChar4);


        charMage = charMageGO.GetComponent<Mage>();
        charWarrior= charWarriorGO.GetComponent<Warrior>();
        charPriest = charPriestGO.GetComponent<Priest>();
        charThief = charThiefGO.GetComponent<Thief>();



        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);

        EnemyUnit = enemyGO.GetComponent<Unit>();

        
        charMageName.SetText(charMage.Charname);
        charWarriorName.SetText(charWarrior.Charname);
        charPriestName.SetText(charPriest.Charname);
        charThiefName.SetText(charThief.Charname);

        EnemyName.SetText(EnemyUnit.unitName);

        textchanger.startupHealth(charMage.maxHP, charWarrior.maxHP, charPriest.maxHP, charThief.maxHP, EnemyUnit.maxHealth);

        textchanger.setLog(EnemyUnit.unitName + " approches...");

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;

        characters = new List<CharacterClass>();
        characters.Add(charMage);
        characters.Add(charWarrior);
        characters.Add(charPriest);
        characters.Add(charThief);

        playTurns = findFastesCharacters(characters);
        PlayerTurn();
    }

    public Queue<CharacterClass> findFastesCharacters(List<CharacterClass>charchters) {
        Queue<CharacterClass> characterQueue = new Queue<CharacterClass>();
        int size = charchters.Count;
        for(int i = 0; i< size; i++) {
            int speed = 0;
            CharacterClass tempobj = null;
            foreach (CharacterClass cha in charchters) {
                if(cha.agility > speed) {
                    speed = cha.agility;
                    tempobj = cha;
                }
            }
            characterQueue.Enqueue(tempobj);
            charchters.Remove(tempobj);
            speed = 0;
        }

        return characterQueue;
    }


    void PlayerTurn() {
        if (playTurns.Count > 0) {
            textchanger.setLog(playTurns.Peek().Charname + " choose an action: ");
        } else {
            
            state = BattleState.ENEMYTURN;
            EnemyTurn();
            characters.Add(charMage);
            characters.Add(charWarrior);
            characters.Add(charPriest);
            characters.Add(charThief);
            playTurns = findFastesCharacters(characters);
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    
    void EnemyTurn() {
        

        state = BattleState.BATTLEPHASE;
        StartCoroutine(BattlePhase());
        
    }

    IEnumerator BattlePhase() {

        Debug.Log("Enemy hits (insert random name)");



        yield return new WaitForSeconds(1);
    }

    public void OnAttackButton() {
        if(state == BattleState.PLAYERTURN) {
            Debug.Log(playTurns.Peek().strength);
            playTurns.Dequeue();
            PlayerTurn();
        }
    }

    public void OnHealButton() {
        
        if (state == BattleState.PLAYERTURN && playTurns.Peek().Charname.Equals("The Priest")) {
            Debug.Log(playTurns.Peek().maxHP);
            playTurns.Dequeue();
            PlayerTurn();
            return;
        } else {
            Debug.Log("This Char cant heat");
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
