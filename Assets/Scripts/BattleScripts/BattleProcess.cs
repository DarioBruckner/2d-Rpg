using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum BattleState { START, PLAYERTURN,ENEMYTURN, BATTLEPHASE, WON, LOST , RUN}
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
        print(Enemy.s_name);
        
        charMageName.SetText(charMage.s_name);
        charWarriorName.SetText(charWarrior.s_name);
        charPriestName.SetText(charPriest.s_name);
        charThiefName.SetText(charThief.s_name);

        EnemyName.SetText(Enemy.s_name);

        textchanger.startupHealth(charMage.n_maxHP, charWarrior.n_maxHP, charPriest.n_maxHP, charThief.n_maxHP, Enemy.n_maxHP, 
            charMage.n_maxMP, charWarrior.n_maxMP, charPriest.n_maxMP, charThief.n_maxMP);

        textchanger.setLog(Enemy.s_name + " approches...");
        

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
                if(cha.n_agility > speed) {
                    speed = cha.n_agility;
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
            if (playTurns.Peek().b_isAlive) {
                textchanger.setLog(playTurns.Peek().s_name + " choose an action: ");
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


        if (charMage.b_isAlive) {
            characters.Add(charMage);
        }
        if (charWarrior.b_isAlive) {
            characters.Add(charWarrior);
        }
        if (charPriest.b_isAlive) {
            characters.Add(charPriest);
        }
        if (charThief.b_isAlive) {
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
            if (targets[rng].b_isAlive) {
                break;
            }

        }

        if(state == BattleState.ENEMYTURN) {
            
            targets[rng].takePhysDamage(playTurns.Peek().n_strength);
            textchanger.setHealthChar(rng + 1, targets[rng].n_HP);
            StartCoroutine(EnemyAttack(targets[rng]));
            

        }

       
        
    }

    public void OnAttackButton() {
        if(state == BattleState.PLAYERTURN) {
            Enemy.takePhysDamage(playTurns.Peek().n_strength);

            
            textchanger.setEnemyHealth(Enemy.n_HP);
            StartCoroutine(PlayerAttack(playTurns.Peek()));
            
        }
    }

    


    IEnumerator PlayerAttack(CharacterClass attackingUnit) {

        
        textchanger.setLog(attackingUnit.s_name + " attacks " + Enemy.s_name);

        yield return new WaitForSeconds(2f);
        playTurns.Dequeue();
        if (!Enemy.b_isAlive) {
            state = BattleState.WON;
            endBattle();
        } else {
            PlayerTurn();
        }
    }

    IEnumerator EnemyAttack(CharacterClass target) {

        textchanger.setLog(Enemy.s_name + " attacks " + target.s_name);

        yield return new WaitForSeconds(2f);

        

        playTurns.Dequeue();

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    IEnumerator SpecialAttack(CharacterClass user, CharacterClass target) {



        yield return new WaitForSeconds(2f);

    }


    IEnumerator PlayerHeal(CharacterClass targetPlayer) { 
        textchanger.setLog(playTurns.Peek().s_name + " heals " + targetPlayer.s_name);
        targetPlayer.getHealed(playTurns.Peek().n_magicalMight);
        textchanger.setHealthCharByName(targetPlayer.s_name, targetPlayer.n_HP);

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
