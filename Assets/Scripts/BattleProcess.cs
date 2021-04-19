using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleProcess : MonoBehaviour
{
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


    public TextMeshProUGUI char1Name;
    public TextMeshProUGUI char2Name;
    public TextMeshProUGUI char3Name;
    public TextMeshProUGUI char4Name;

    public TextMeshProUGUI EnemyName;
    


    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }


    void SetupBattle() {
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

        char1Name.SetText(char1Unit.unitName);
        char2Name.SetText(char2Unit.unitName);
        char3Name.SetText(char3Unit.unitName);
        char4Name.SetText(char4Unit.unitName);

        EnemyName.SetText(EnemyUnit.unitName);



    }

}
