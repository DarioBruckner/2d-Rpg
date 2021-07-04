using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, BATTLEPHASE, WON, LOST, RUN }
public enum PlayerStates { };

public class BattleProcess : MonoBehaviour
{

    public LevelLoader loader;

    public GameObject charMagePrefab;
    public GameObject charWarriorPrefab;
    public GameObject charPriestPrefab;
    public GameObject charThiefPrefab;

    public GameObject wolfPrefab;
    public GameObject drakePrefab;
    public GameObject batPrefab;
    public GameObject golemPrefab;

    public Transform playerBattleStationChar1;
    public Transform playerBattleStationChar2;
    public Transform playerBattleStationChar3;
    public Transform playerBattleStationChar4;

    public Transform enemyBattleStation;


    public GameObject buttonPrefab;

    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;
    public Button buttonFour;



    List<CharacterClass> characters;
    List<CharacterClass> deadCharacters;
    List<PlayerClass> targets;

    PlayerClass charMage;
    PlayerClass charWarrior;
    PlayerClass charPriest;
    PlayerClass charThief;

    MonsterClass Enemy;

    Queue<CharacterClass> playTurns;


    public TextMeshProUGUI charMageName;
    public TextMeshProUGUI charWarriorName;
    public TextMeshProUGUI charPriestName;
    public TextMeshProUGUI charThiefName;

    public TextMeshProUGUI EnemyName;

    public TextChanger textchanger;


    public BattleState state;


    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }


    IEnumerator SetupBattle()
    {

        GameObject charMageGO = Instantiate(charMagePrefab, playerBattleStationChar1);
        GameObject charWarriorGO = Instantiate(charWarriorPrefab, playerBattleStationChar2);
        GameObject charPriestGO = Instantiate(charPriestPrefab, playerBattleStationChar3);
        GameObject charThiefGO = Instantiate(charThiefPrefab, playerBattleStationChar4);


        charMage = WorldComponents.mage;
        charPriest = WorldComponents.priest;
        charWarrior = WorldComponents.warrior;
        charThief = WorldComponents.thief;

        GameObject enemyGO;
        if (WorldComponents.m_currentEnemy == "Wolf")
        {
            enemyGO = Instantiate(wolfPrefab, enemyBattleStation);
            Enemy = enemyGO.GetComponent<Wolf>();
            if(WorldComponents.b_ringquest)
            {
                Enemy.initialize(7);
            } else
            {
                Enemy.initialize(1);
            }
            
        }
        else if (WorldComponents.m_currentEnemy == "Drake")
        {
            enemyGO = Instantiate(drakePrefab, enemyBattleStation);
            Enemy = enemyGO.GetComponent<Drake>();
            if (WorldComponents.b_ringquest)
            {
                Enemy.initialize(7);
            }
            else
            {
                Enemy.initialize(3);
            }
            
        }
        else if (WorldComponents.m_currentEnemy == "Bat")
        {
            enemyGO = Instantiate(batPrefab, enemyBattleStation);
            Enemy = enemyGO.GetComponent<Bat>();
            if (WorldComponents.b_ringquest)
            {
                Enemy.initialize(7);
            }
            else
            {
                Enemy.initialize(2);
            }
            
        }
        else
        {
            enemyGO = Instantiate(golemPrefab, enemyBattleStation);
            Enemy = enemyGO.GetComponent<Golem>();
            if (WorldComponents.b_ringquest)
            {
                Enemy.initialize(7);
            }
            else
            {
                Enemy.initialize(4);
            }
            
        }

        createDefaultButtons();




        charMageName.SetText(charMage.s_name);
        charWarriorName.SetText(charWarrior.s_name);
        charPriestName.SetText(charPriest.s_name);
        charThiefName.SetText(charThief.s_name);

        EnemyName.SetText(Enemy.s_name);

        textchanger.startupHealth(charMage.n_maxHP, charMage.n_HP, charWarrior.n_maxHP, charWarrior.n_HP, charPriest.n_maxHP, charPriest.n_HP, charThief.n_maxHP, charThief.n_HP, Enemy.n_HP,
            charMage.n_maxMP, charMage.n_MP, charWarrior.n_maxMP, charWarrior.n_MP, charPriest.n_maxMP, charPriest.n_MP, charThief.n_maxMP, charThief.n_MP);

        textchanger.setLog(Enemy.s_name + " approches...");


        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;

        characters = new List<CharacterClass>();
        characters.Add(charThief);
        characters.Add(charMage);
        characters.Add(charPriest);
        characters.Add(charWarrior);


        characters.Add(Enemy);

        targets = new List<PlayerClass>();
        targets.Add(charMage);
        targets.Add(charPriest);
        targets.Add(charWarrior);
        targets.Add(charThief);


        deadCharacters = new List<CharacterClass>();



        playTurns = findFastesCharacters(characters);


        PlayerTurn();
    }

    public void removeAllOnClickListeners()
    {
        buttonOne.onClick.RemoveAllListeners();
        buttonTwo.onClick.RemoveAllListeners();
        buttonThree.onClick.RemoveAllListeners();
        buttonFour.onClick.RemoveAllListeners();
    }

    public void activateAllButtons()
    {
        buttonOne.gameObject.SetActive(true);
        buttonTwo.gameObject.SetActive(true);
        buttonThree.gameObject.SetActive(true);
        buttonFour.gameObject.SetActive(true);
    }

    public void deactivateAllButtons()
    {
        buttonOne.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);
        buttonFour.gameObject.SetActive(false);
    }

    public void createDefaultButtons()
    {

        removeAllOnClickListeners();

        activateAllButtons();


        buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText("Basic Attack");
        buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText("Special Attack");
        buttonThree.GetComponentInChildren<TextMeshProUGUI>().SetText("Items");
        buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Run");


        buttonOne.onClick.AddListener(OnAttackButton);
        buttonTwo.onClick.AddListener(displaySpecialMoves);
        buttonThree.onClick.AddListener(displayItems);
        buttonFour.onClick.AddListener(runFromBattle);


    }



    public void displaySpecialMoves()
    {
        CharacterClass currentPlayer = playTurns.Peek();
        MonsterClass currentEnemy = Enemy;
        List<AbilityClass> abilities = currentPlayer.abilities;
        buttonThree.gameObject.SetActive(false);





        if (currentPlayer.abilities.Count == 1)
        {
            buttonTwo.gameObject.SetActive(false);

            buttonOne.onClick.RemoveAllListeners();
            buttonTwo.onClick.RemoveAllListeners();
            buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(abilities[0].s_name);
            buttonOne.onClick.AddListener(delegate { useAbility(abilities[0], currentPlayer, currentEnemy); });
            buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
            buttonFour.onClick.RemoveAllListeners();
            buttonFour.onClick.AddListener(createDefaultButtons);


        }
        else if (currentPlayer.abilities.Count == 0)
        {
            buttonOne.gameObject.SetActive(false);
            buttonTwo.gameObject.SetActive(false);
            buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
            buttonFour.onClick.RemoveAllListeners();
            buttonFour.onClick.AddListener(createDefaultButtons);
        }
        else
        {
            buttonOne.onClick.RemoveAllListeners();
            buttonTwo.onClick.RemoveAllListeners();
            buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(abilities[0].s_name);
            buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(abilities[1].s_name);
            buttonOne.onClick.AddListener(delegate { useAbility(abilities[0], currentPlayer, currentEnemy); });
            buttonTwo.onClick.AddListener(delegate { useAbility(abilities[1], currentPlayer, currentEnemy); });
            buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
            buttonFour.onClick.RemoveAllListeners();
            buttonFour.onClick.AddListener(createDefaultButtons);

        }

    }

    public void displayItems()
    {
        CharacterClass currentPlayer = playTurns.Peek();
        List<ItemClass> items = new List<ItemClass>();

        foreach (ItemClass item in WorldComponents.items)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }


        removeAllOnClickListeners();

        if (items.Count == 1)
        {
            buttonThree.gameObject.SetActive(false);
            buttonTwo.gameObject.SetActive(false);
            buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(items[0].s_itemName);
            if (items[0].s_itemName == "Healing Potion")
            {
                buttonOne.onClick.AddListener(delegate { useHealthPotion(items[0]); });
            }
            else
            {
                buttonOne.onClick.AddListener(delegate { useMagicPotion(items[0]); });
            }

        }
        else if (items.Count == 2)
        {

            buttonThree.gameObject.SetActive(false);
            buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(items[0].s_itemName);
            if (items[0].s_itemName == "Healing Potion")
            {
                buttonOne.onClick.AddListener(delegate { useHealthPotion(items[0]); });
            }
            else
            {
                buttonOne.onClick.AddListener(delegate { useMagicPotion(items[0]); });
            }

            buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(items[1].s_itemName);

            if (items[1].s_itemName == "Healing Potion")
            {
                buttonTwo.onClick.AddListener(delegate { useHealthPotion(items[1]); });
            }
            else
            {
                buttonTwo.onClick.AddListener(delegate { useMagicPotion(items[1]); });
            }

        }
        else
        {
            buttonThree.gameObject.SetActive(false);
            buttonTwo.gameObject.SetActive(false);
            buttonOne.gameObject.SetActive(false);
        }





        buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
        buttonFour.onClick.AddListener(createDefaultButtons);
        //buttonTwo.onClick.AddListener(delegate { useMagicPotion(items[0]); });


    }

    public Queue<CharacterClass> findFastesCharacters(List<CharacterClass> charchters)
    {
        Queue<CharacterClass> characterQueue = new Queue<CharacterClass>();
        int size = charchters.Count;
        for (int i = 0; i < size; i++)
        {
            int speed = 0;
            CharacterClass tempobj = null;
            foreach (CharacterClass cha in charchters)
            {

                if (cha.n_agility > speed)
                {
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

    void PlayerTurn()
    {
        if (state == BattleState.WON || state == BattleState.LOST)
        {
            endBattle();
        }
        else if (playTurns.Count > 0 && typeof(PlayerClass).IsInstanceOfType(playTurns.Peek()))
        {
            state = BattleState.PLAYERTURN;
            if (playTurns.Peek().b_isAlive)
            {
                textchanger.setLog(playTurns.Peek().s_name + " choose an action: ");
            }
            else
            {
                playTurns.Dequeue();
                PlayerTurn();
            }
        }
        else if (playTurns.Count > 0 && typeof(MonsterClass).IsInstanceOfType(playTurns.Peek()))
        {
            state = BattleState.ENEMYTURN;
            EnemyTurn();

        }
        else
        {

            addCharstoList();
            playTurns = findFastesCharacters(characters);
            PlayerTurn();
        }
    }

    void addCharstoList()
    {

        if (charThief.b_isAlive)
        {
            characters.Add(charThief);
        }
        if (charMage.b_isAlive)
        {
            characters.Add(charMage);
        }
        if (charPriest.b_isAlive)
        {
            characters.Add(charPriest);
        }
        if (charWarrior.b_isAlive)
        {
            characters.Add(charWarrior);
        }


        characters.Add(Enemy);


        if (characters.Count <= 1)
        {
            state = BattleState.LOST;
            endBattle();
        }
    }


    void addDeadCharsToList() {
        if (!charThief.b_isAlive) {
            deadCharacters.Add(charThief);
        }
        if (!charMage.b_isAlive) {
            deadCharacters.Add(charMage);
        }
        if (!charPriest.b_isAlive) {
            deadCharacters.Add(charPriest);
        }
        if (!charWarrior.b_isAlive) {
            deadCharacters.Add(charWarrior);
        }
    }

    void addChatstoTargets() {
        targets.Clear();
        if (charMage.b_isAlive)
        {
            targets.Add(charMage);
        }
        if (charWarrior.b_isAlive)
        {
            targets.Add(charWarrior);
        }
        if (charPriest.b_isAlive)
        {
            targets.Add(charPriest);
        }
        if (charThief.b_isAlive)
        {
            targets.Add(charThief);
        }
    }

    void EnemyTurn()
    {
        int rng = 0;
        while (true)
        {
            rng = Random.Range(0, targets.Count);
            if (targets[rng].b_isAlive)
            {
                break;
            }

        }

        if (state == BattleState.ENEMYTURN)
        {
            CharacterClass tar = targets[rng];
            Enemy.attack(ref tar);
            textchanger.setHealthCharByName(targets[rng].s_name, targets[rng].n_HP);
            StartCoroutine(EnemyAttack(targets[rng]));


        }



    }

    public void OnAttackButton()
    {
        if (state == BattleState.PLAYERTURN)
        {
            Enemy.takePhysDamage(playTurns.Peek().n_strength);


            textchanger.setEnemyHealth(Enemy.n_HP);
            StartCoroutine(PlayerAttack(playTurns.Peek()));

        }
    }

    public void useAbility(AbilityClass ability, CharacterClass User, MonsterClass target)
    {

        if (ability.b_targetEnemy == true)
        {
            if (ability.enemyAction(ref User, ref target))
            {
                textchanger.setEnemyHealth(Enemy.n_HP);
                textchanger.setManaByName(User.s_name, User.n_MP);
                StartCoroutine(SpecialAttack(ability.s_name, User.s_name, target.s_name, true));

            }
            else
            {
                StartCoroutine(SpecialAttack(ability.s_name, User.s_name, target.s_name, false));
            }
            createDefaultButtons();
        } else {
            if(ability.s_name == "Heal") {
                displayHeal(ability, User, target);
            } else {
                displayRevive(ability, User, target);
            }
        }
    }


    public void displayHeal(AbilityClass ability, CharacterClass User, MonsterClass target) {
        removeAllOnClickListeners();
        activateAllButtons();
        addChatstoTargets();

        switch (targets.Count) {
            case 1:

                buttonTwo.gameObject.SetActive(false);
                buttonThree.gameObject.SetActive(false);
                buttonFour.gameObject.SetActive(false);

                buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[0].s_name);

                buttonOne.onClick.AddListener(delegate { startHeal(ability, targets[0]); });
                break;
            case 2:
                buttonThree.gameObject.SetActive(false);
                buttonFour.gameObject.SetActive(false);

                buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[0].s_name);
                buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[1].s_name);

                buttonOne.onClick.AddListener(delegate { startHeal(ability, targets[0]); });
                buttonTwo.onClick.AddListener(delegate { startHeal(ability, targets[1]); });
                break;
            case 3:
                buttonFour.gameObject.SetActive(false);

                buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[0].s_name);
                buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[1].s_name);
                buttonThree.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[2].s_name);

                buttonOne.onClick.AddListener(delegate { startHeal(ability, targets[0]); });
                buttonTwo.onClick.AddListener(delegate { startHeal(ability, targets[1]); });
                buttonThree.onClick.AddListener(delegate { startHeal(ability, targets[2]); });
                break;
            case 4:
                buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[0].s_name);
                buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[1].s_name);
                buttonThree.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[2].s_name);
                buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[3].s_name);

                buttonOne.onClick.AddListener(delegate { startHeal(ability, targets[0]); });
                buttonTwo.onClick.AddListener(delegate { startHeal(ability, targets[1]); });
                buttonThree.onClick.AddListener(delegate { startHeal(ability, targets[2]); });
                buttonFour.onClick.AddListener(delegate { startHeal(ability, targets[3]); });
                break;
        }
    }


    public void displayRevive(AbilityClass ability, CharacterClass User, MonsterClass target) {
        removeAllOnClickListeners();
        activateAllButtons();
        addDeadCharsToList();

        switch (deadCharacters.Count) {
            case 0:
                buttonOne.gameObject.SetActive(false);
                buttonTwo.gameObject.SetActive(false);
                buttonThree.gameObject.SetActive(false);


                buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
                buttonFour.onClick.AddListener(createDefaultButtons);
                break;
            case 1:

                buttonTwo.gameObject.SetActive(false);
                buttonThree.gameObject.SetActive(false);
                

                buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[0].s_name);

                buttonOne.onClick.AddListener(delegate { startRevive(ability, targets[0]); });

                buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
                buttonFour.onClick.AddListener(createDefaultButtons);
                break;
            case 2:
                buttonThree.gameObject.SetActive(false);
                

                buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[0].s_name);
                buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[1].s_name);

                buttonOne.onClick.AddListener(delegate { startRevive(ability, targets[0]); });
                buttonTwo.onClick.AddListener(delegate { startRevive(ability, targets[1]); });

                buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
                buttonFour.onClick.AddListener(createDefaultButtons);
                break;
            case 3:
                

                buttonOne.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[0].s_name);
                buttonTwo.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[1].s_name);
                buttonThree.GetComponentInChildren<TextMeshProUGUI>().SetText(targets[2].s_name);

                buttonOne.onClick.AddListener(delegate { startRevive(ability, targets[0]); });
                buttonTwo.onClick.AddListener(delegate { startRevive(ability, targets[1]); });
                buttonThree.onClick.AddListener(delegate { startRevive(ability, targets[2]); });

                buttonFour.GetComponentInChildren<TextMeshProUGUI>().SetText("Back");
                buttonFour.onClick.AddListener(createDefaultButtons);
                break;
        }

    }

    public void useHealthPotion(ItemClass item) {
        StartCoroutine(HealthPotion(playTurns.Peek(), item));
    }

    public void useMagicPotion(ItemClass item)
    {
        StartCoroutine(MagicPotion(playTurns.Peek(), item));
    }

    public void startHeal(AbilityClass ability, PlayerClass target)
    {


        StartCoroutine(PlayerHeal(ability, target));



    }

 
    public void startRevive(AbilityClass ability, PlayerClass target) {
        StartCoroutine(PlayerRevive(ability, target));
    }


    IEnumerator PlayerAttack(CharacterClass attackingUnit)
    {
        StartCoroutine(DoBlinks(Enemy.s_name, new Color(0, 0, 0, 0)));
        textchanger.setLog(attackingUnit.s_name + " attacks " + Enemy.s_name);
        deactivateAllButtons();

        switch (attackingUnit.s_name)
        {
            case "The Mage":
                GameObject.Find("Mage(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
            case "The Warrior":
                GameObject.Find("Warrior(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
            case "The Thief":
                GameObject.Find("Thief(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
            case "The Priest":
                GameObject.Find("Priest(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
        }


        yield return new WaitForSeconds(2f);


        playTurns.Dequeue();
        if (!Enemy.b_isAlive)
        {
            state = BattleState.WON;
            endBattle();
        }
        else
        {
            PlayerTurn();
        }
        activateAllButtons();
    }

    IEnumerator EnemyAttack(CharacterClass target)
    {
        StartCoroutine(DoBlinks(target.s_name, new Color(0, 0, 0, 0)));
        Debug.Log(WorldComponents.m_currentEnemy);
        switch (WorldComponents.m_currentEnemy)
        {
            case "Wolf":
                GameObject.Find("Wolf(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
            case "Bat":
                GameObject.Find("Bat(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
            case "Drake":
                GameObject.Find("Drake(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
            case "GolemBoss":
                GameObject.Find("Golem(Clone)").GetComponent<Animator>().SetTrigger("attack");
                break;
        }

        textchanger.setLog(Enemy.s_name + " attacks " + target.s_name);

        deactivateAllButtons();

        yield return new WaitForSeconds(2f);

        activateAllButtons();

        playTurns.Dequeue();

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    IEnumerator SpecialAttack(string abilityname, string username, string targetname, bool mana)
    {
        if (mana)
        {
            textchanger.setLog(username + " used " + abilityname + " on " + targetname);
            playTurns.Dequeue();
            switch (username)
            {
                case "The Mage":
                    GameObject.Find("Mage(Clone)").GetComponent<Animator>().SetTrigger("attack");
                    break;
                case "The Warrior":
                    GameObject.Find("Warrior(Clone)").GetComponent<Animator>().SetTrigger("attack");
                    break;
                case "The Thief":
                    GameObject.Find("Thief(Clone)").GetComponent<Animator>().SetTrigger("attack");
                    break;
                case "The Priest":
                    GameObject.Find("Priest(Clone)").GetComponent<Animator>().SetTrigger("attack");
                    break;
            }
            StartCoroutine(DoBlinks(targetname, new Color(0, 0, 0, 0)));

        }
        else
        {
            textchanger.setLog("You dont have enough mana for " + abilityname);
        }
        deactivateAllButtons();


        yield return new WaitForSeconds(2f);

        activateAllButtons();

        if (!Enemy.b_isAlive)
        {
            state = BattleState.WON;
            endBattle();
        }
        else
        {
            PlayerTurn();
        }
    }


    IEnumerator PlayerHeal(AbilityClass ability, PlayerClass targetPlayer)
    {
        StartCoroutine(DoBlinks(targetPlayer.s_name, new Color(255,174,0)));

        CharacterClass user = playTurns.Peek();
        string abilityname = ability.s_name;
        string username = user.s_name;
        string targetname = targetPlayer.s_name;


        if (ability.allyAction(ref user, ref targetPlayer))
        {
            textchanger.setManaByName(username, user.n_MP);
            textchanger.setHealthCharByName(targetname, targetPlayer.n_HP);
            textchanger.setLog(username + " healed " + targetname);
        }
        else
        {
            textchanger.setLog("Not enough mana to cast " + abilityname);
        }
        deactivateAllButtons();
        yield return new WaitForSeconds(2f);

        activateAllButtons();

        createDefaultButtons();
        playTurns.Dequeue();
        PlayerTurn();

    }


    IEnumerator PlayerRevive(AbilityClass ability, PlayerClass targetPlayer) {
        CharacterClass user = playTurns.Peek();
        string abilityname = ability.s_name;
        string username = user.s_name;
        string targetname = targetPlayer.s_name;


        if (ability.allyAction(ref user, ref targetPlayer)) {
            textchanger.setManaByName(username, user.n_MP);
            textchanger.setHealthCharByName(targetname, targetPlayer.n_HP);
            textchanger.setLog(username + " revived " + targetname);
        } else {
            textchanger.setLog("Not enough mana to cast " + abilityname);
        }

        yield return new WaitForSeconds(2f);

        activateAllButtons();

        createDefaultButtons();
        playTurns.Dequeue();
        PlayerTurn();
    }



    IEnumerator HealthPotion(CharacterClass ItemUser, ItemClass item) {

        StartCoroutine(DoBlinks(ItemUser.s_name, new Color(255, 174, 0)));
        deactivateAllButtons();

        item.action(ref ItemUser);
        textchanger.setHealthCharByName(ItemUser.s_name, ItemUser.n_HP);
        textchanger.setLog(playTurns.Peek().s_name + " used a Health Potion");

        WorldComponents.items.Remove(item);
        WorldComponents.items.Remove(item);

        yield return new WaitForSeconds(2f);
        activateAllButtons();
        playTurns.Dequeue();
        createDefaultButtons();
        PlayerTurn();

    }


    IEnumerator MagicPotion(CharacterClass ItemUser, ItemClass item)
    {
        StartCoroutine(DoBlinks(ItemUser.s_name, new Color(0, 132, 255)));

        deactivateAllButtons();
        item.action(ref ItemUser);
        textchanger.setManaByName(playTurns.Peek().s_name, ItemUser.n_MP);
        textchanger.setLog(playTurns.Peek().s_name + " used a Magic Potion");

        WorldComponents.items.Remove(item);
        WorldComponents.items.Remove(item);

        yield return new WaitForSeconds(2f);
        activateAllButtons();
        playTurns.Dequeue();
        createDefaultButtons();
        PlayerTurn();
    }

    IEnumerator DoBlinks(string target, Color color)
    {
        float duration = 1f;
        float blinkTime = 0.05f;
        bool blinkSwitch = true;
        while (duration >= 0)
        {
            duration -= blinkTime;
            switch (target)
            {
                case "The Mage":
                    GameObject.Find("Mage(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
                case "The Warrior":
                    GameObject.Find("Warrior(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
                case "The Thief":
                    GameObject.Find("Thief(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
                case "The Priest":
                    GameObject.Find("Priest(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
                case "Wolf":
                    GameObject.Find("Wolf(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
                case "Bat":
                    GameObject.Find("Bat(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
                case "Drake":
                    GameObject.Find("Drake(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
                case "GolemBoss":
                    GameObject.Find("Golem(Clone)").GetComponent<SpriteRenderer>().color = blinkSwitch ? color : new Color(255, 255, 255);
                    break;
            }
            blinkSwitch = !blinkSwitch;
            yield return new WaitForSeconds(blinkTime);
        }

        switch (target)
        {
            case "The Mage":
                GameObject.Find("Mage(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
            case "The Warrior":
                GameObject.Find("Warrior(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
            case "The Thief":
                GameObject.Find("Thief(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
            case "The Priest":
                GameObject.Find("Priest(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
            case "Wolf":
                GameObject.Find("Wolf(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
            case "Bat":
                GameObject.Find("Bat(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
            case "Drake":
                GameObject.Find("Drake(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
            case "GolemBoss":
                GameObject.Find("Golem(Clone)").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                break;
        }
    }

    void runFromBattle()
    {
        int rng = Random.Range(0, 100);
        StartCoroutine(runAttempt(rng));

    }

    IEnumerator runAttempt(int rng)
    {

        if (rng < 50)
        {
            textchanger.setLog("The way was blocked by the enemy");
            playTurns.Dequeue();

        }
        else
        {
            textchanger.setLog("You Successfuly escaped");
            state = BattleState.RUN;
        }


        deactivateAllButtons();
        yield return new WaitForSeconds(1f);

        if (state == BattleState.RUN)
        {
            StartCoroutine(changeLevel());
        }
        else
        {
            activateAllButtons();
            PlayerTurn();
        }
    }


    void endBattle()
    {
        if (state == BattleState.WON)
        {
            WorldComponents.mage.gainExp(Enemy.n_expDrop);
            WorldComponents.priest.gainExp(Enemy.n_expDrop);
            WorldComponents.warrior.gainExp(Enemy.n_expDrop);
            WorldComponents.thief.gainExp(Enemy.n_expDrop);

            textchanger.setLog("You won, well done");
            WorldComponents.b_enemyDefeated = true;
            StartCoroutine(changeLevel());
        }
        else if (state == BattleState.LOST)
        {
            textchanger.setLog("Oh no you lost, try again!");
            StartCoroutine(changeLevelDeath());
        }
    }

    IEnumerator changeLevel()
    {

        yield return new WaitForSeconds(2f);

        loader.LoadWorld();
    }
    IEnumerator changeLevelDeath()
    {

        yield return new WaitForSeconds(2f);

        loader.LoadDeathScreen();
    }

    private void Update()
    {
        if (WorldComponents.warrior.n_HP <= 0)
        {
            GameObject.Find("Warrior(Clone)").GetComponent<Animator>().SetBool("dead", true);
        }
        else
        {
            GameObject.Find("Warrior(Clone)").GetComponent<Animator>().SetBool("dead", false);
        }
        if (WorldComponents.thief.n_HP <= 0)
        {
            GameObject.Find("Thief(Clone)").GetComponent<Animator>().SetBool("dead", true);
        }
        else
        {
            GameObject.Find("Thief(Clone)").GetComponent<Animator>().SetBool("dead", false);
        }
        if (WorldComponents.mage.n_HP <= 0)
        {
            GameObject.Find("Mage(Clone)").GetComponent<Animator>().SetBool("dead", true);
        }
        else
        {
            GameObject.Find("Mage(Clone)").GetComponent<Animator>().SetBool("dead", false);
        }
        if (WorldComponents.priest.n_HP <= 0)
        {
            GameObject.Find("Priest(Clone)").GetComponent<Animator>().SetBool("dead", true);
        }
        else
        {
            GameObject.Find("Priest(Clone)").GetComponent<Animator>().SetBool("dead", false);
        }

        if (Enemy.n_HP <= 0)
        {
            switch (WorldComponents.m_currentEnemy)
            {
                case "Wolf":
                    GameObject.Find("Wolf(Clone)").GetComponent<Animator>().SetBool("dead", true);
                    break;
                case "Bat":
                    GameObject.Find("Bat(Clone)").GetComponent<Animator>().SetBool("dead", true);
                    break;
                case "Drake":
                    GameObject.Find("Drake(Clone)").GetComponent<Animator>().SetBool("dead", true);
                    break;
                case "GolemBoss":
                    GameObject.Find("Golem(Clone)").GetComponent<Animator>().SetBool("dead", true);
                    break;
            }

        }
    }
}
