using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI namespace erstellt (UI Elemente von Unity können verwendet werden)

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST } // Enumeration BattleState definiert (öffentlich)

public class BattleSystem : MonoBehaviour // BattleState erbt von MonoBehavior

{

    public GameObject playerPrefab; // Referenz für player unit
    public GameObject enemyPrefab; // Referenz für enemy unit

    public Transform playerBattleStation; // Referenz der Koordinaten von playerBattleStation
    public Transform enemyBattleStation; // Referenz der Koordinaten von enemyBattleStation 

    Unit playerUnit; // Eine (private?) Variable von Typ Unit erstellen?
    Unit enemyUnit; // Eine (private?) Variable von Typ Unit erstellen?

    public Text dialogueText; // Öffentliche Methode(?) dialogueText von Typ Text von UI Namespace?


    public BattleState state; // Variable für das enum Battlestate erstellt

    void Start() // MonoBehaviour's "Callback" Methode
    {
        state = BattleState.START; // Der Variable state den enum Wert Start von BattleState zuweisen
        SetupBattle(); // Verweis auf SetupBattle Methode
    }

    void SetupBattle() // Methode SetupBattle erstellen
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation); // Eine Referenz von der Instanziierung erstellen (playerGO) ?
        // Instanziieren des player prefabs als child von und auf playerBattleStation
        playerUnit = playerGO.GetComponent<Unit>(); // Variable playerUnit - Unit Komponente auf die playerGO Variable holen ?

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation); // Das gleiche wie darüber nur mit enemy unit
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = $"A wild {enemyUnit.unitName} approaches..."; // Textausgabe über dialogueText Methode?
        //Weiter gehts morgen (vid: 14:30)
    }

}
