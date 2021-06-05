using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum BattleState { START, PLAYERTURN,ENEMYTURN, BATTLEPHASE, WON, LOST }
public enum PlayerStates { };

public class BattleProcess : MonoBehaviour {

    public LevelLoader loader;
    
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
    List<CharacterClass> targets;

    Mage charMage;
    Warrior charWarrior;
    Priest charPriest;
    Thief charThief;

    Wolf Enemy;

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

        Enemy = enemyGO.GetComponent<Wolf>();

        
        charMageName.SetText(charMage.Charname);
        charWarriorName.SetText(charWarrior.Charname);
        charPriestName.SetText(charPriest.Charname);
        charThiefName.SetText(charThief.Charname);

        EnemyName.SetText(Enemy.Charname);

        textchanger.startupHealth(charMage.maxHP, charWarrior.maxHP, charPriest.maxHP, charThief.maxHP, Enemy.maxHP, charMage.maxMP, charWarrior.maxMP, charPriest.maxMP, charThief.maxMP);

        textchanger.setLog(Enemy.Charname + " approches...");

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;

        characters = new List<CharacterClass>();
        characters.Add(charMage);
        characters.Add(charWarrior);
        characters.Add(charPriest);
        characters.Add(charThief);
        characters.Add(Enemy);

        targets = new List<CharacterClass>();

        targets.Add(charMage);
        targets.Add(charWarrior);
        targets.Add(charPriest);
        targets.Add(charThief);

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
        if (state == BattleState.WON || state == BattleState.LOST) {
            endBattle();
        } else if (playTurns.Count > 0 && typeof(PlayerClass).IsInstanceOfType(playTurns.Peek())) {
            state = BattleState.PLAYERTURN;
            if (playTurns.Peek().isAlive) {
                textchanger.setLog(playTurns.Peek().Charname + " choose an action: ");
            } else {
                playTurns.Dequeue();
                PlayerTurn();
            }
        } else if (playTurns.Count > 0 && typeof(MonsterClass).IsInstanceOfType(playTurns.Peek())) {
            state = BattleState.ENEMYTURN;
            EnemyTurn();

        } else {



            addCharstoList();
            playTurns = findFastesCharacters(characters);
            PlayerTurn();
        }
    }

    void addCharstoList() {


        if (charMage.isAlive) {
            characters.Add(charMage);
        }
        if (charWarrior.isAlive) {
            characters.Add(charWarrior);
        }
        if (charPriest.isAlive) {
            characters.Add(charPriest);
        }
        if (charThief.isAlive) {
            characters.Add(charThief);
        }
        characters.Add(Enemy);
        

        if(characters.Count <= 1){
            state = BattleState.LOST;
            endBattle();
        }
    }

    void EnemyTurn() {
        int rng = 0;
        while (true) {
            rng = Random.Range(0, targets.Count);
            if (targets[rng].isAlive) {
                break;
            }

        }

        if(state == BattleState.ENEMYTURN) {
            
            targets[rng].takePhysDamage(playTurns.Peek().strength);
            textchanger.setHealthChar(rng + 1, targets[rng].HP);
            StartCoroutine(EnemyAttack(targets[rng]));
            

        }

       
        
    }

    public void OnAttackButton() {
        if(state == BattleState.PLAYERTURN) {
            Enemy.takePhysDamage(playTurns.Peek().strength);

            
            textchanger.setEnemyHealth(Enemy.HP);
            StartCoroutine(PlayerAttack(playTurns.Peek()));
            
        }
    }

    public void OnHealButton() {
        
        if (state == BattleState.PLAYERTURN && playTurns.Peek().Charname.Equals("The Priest")) {

            StartCoroutine(PlayerHeal());
            playTurns.Dequeue();
            PlayerTurn();
            return;
        } else {
            textchanger.setLog("This Character can not Heal");
        }
    }

    IEnumerator PlayerAttack(CharacterClass attackingUnit) {

        
        textchanger.setLog(attackingUnit.Charname + " attacks " + Enemy.Charname);

        yield return new WaitForSeconds(2f);
        playTurns.Dequeue();
        if (!Enemy.isAlive) {
            state = BattleState.WON;
            endBattle();
        } else {
            PlayerTurn();
        }
    }

    IEnumerator EnemyAttack(CharacterClass target) {

        textchanger.setLog(Enemy.Charname + " attacks " + target.Charname);

        yield return new WaitForSeconds(2f);

        

        playTurns.Dequeue();

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerHeal() {
        addCharstoList();
        CharacterClass t = playTurns.Peek();
       
        textchanger.setLog(playTurns.Peek().Charname + " heals " + t.Charname);
        t.getHealed(playTurns.Peek().magicalMight);
        textchanger.setHealthCharByName(t.Charname, t.HP);

        yield return new WaitForSeconds(2f);

        PlayerTurn();
    }


    

    void endBattle() {
        if(state == BattleState.WON) {
            textchanger.setLog("You won, well done");
            StartCoroutine(changeLevel());
        }else if (state == BattleState.LOST) {
            textchanger.setLog("Oh no you lost, try again!");
            StartCoroutine(changeLevel());
        }
        
    }

    IEnumerator changeLevel() {

        yield return new WaitForSeconds(2f);

        loader.LoadWorld();
    }
}
