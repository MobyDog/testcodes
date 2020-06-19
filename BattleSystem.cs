using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI; // UI namespace erstellt (UI Elemente von Unity können verwendet werden)

// Folgende Bugs sind mir aufgefallen:
// - Man kann in einem Zug mehrmals nacheinander angreifen
// - Wenn der Gegner stirbt, greift er trotzdem noch so oft an wie man selbst

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST } // Enumeration BattleState definiert (öffentlich)

public class BattleSystem : MonoBehaviour // BattleState erbt von MonoBehavior

{

    public GameObject playerPrefab; // Referenz für player unit
    public GameObject enemyPrefab; // Referenz für enemy unit

    public Transform playerBattleStation; // Referenz der Koordinaten von playerBattleStation
    public Transform enemyBattleStation; // Referenz der Koordinaten von enemyBattleStation 

    Unit playerUnit; // Private Variable von Datentyp Unit
    Unit enemyUnit; // Private Variable von Datentyp Unit

    public Text dialogueText; // Öffentliche Variable (.UI) von Datentyp Text

    public BattleHUD playerHUD; // Referenz für player/enemyHUD (im Editor)
    public BattleHUD enemyHUD;


    public BattleState state; // Variable für das enum Battlestate erstellt

    void Start() // MonoBehaviour's "Callback" Methode
    {
        state = BattleState.START; // Der Variable state den enum Wert Start von BattleState zuweisen
        StartCoroutine(SetupBattle()); // Verweis auf SetupBattle Methode und starten der Coroutine
    }

    IEnumerator SetupBattle() // Methode mit dem Rückgabewert IEnumerator
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation); // Eine Referenz von der Instanziierung erstellen (playerGO)
        // Instanziieren des player prefabs (als child von und auf playerBattleStation?)
        playerUnit = playerGO.GetComponent<Unit>(); // Eine Komponente von der Klasse Unit holen und in die Variable playerUnit speichern

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation); // Das gleiche wie darüber nur mit enemy unit
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = $"A wild {enemyUnit.unitName} approaches..."; // Property/öffentliche Variable angesprochen

        playerHUD.SetHUD(playerUnit); // Dem playerUnit werden die Werte aus der SetHUD Methode in der BattleHUD Klasse zugewiesen
        enemyHUD.SetHUD(enemyUnit); // also die Hp Leiste wird aktuallisiert

        yield return new WaitForSeconds(2f);

        // "Trancision to the Players turn"
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        //Damage the enemy
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        //Update the UI
        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The Attack is successful!";

        yield return new WaitForSeconds(2f);

        // Check if the enemy is dead
        if (isDead)
        {
            // End the battle
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            // Enemy turn
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        // Change state based on what happened
    }

    IEnumerator EnemyTurn() // Gegner am Zug
    {
        dialogueText.text = enemyUnit.unitName + " attacks!"; // Textausgabe mit Variable des Gegnerischen Namen

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage); // Verweis auf bool "isDead", Player kriegt Schaden von Enemy

        playerHUD.SetHP(playerUnit.currentHP); // HUD Abfrage

        yield return new WaitForSeconds(1f);

        if(isDead) // bool isDead wird definiert
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
        if (state == BattleState.WON) // If Bedingung, wenn state auf .WON schaltet
        {
            dialogueText.text = "You won the battle!";
        }

        else if (state == BattleState.LOST) // Andere If Bedingung, wenn state auf .LOST schaltet
        {
            dialogueText.text = "You were defeated";
        }

    }
    


    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:"; //Information für den Spieler, dass es an der Reihe ist
    }

    IEnumerator PlayerHeal() // PlayerHeal Methode mit Coroutine
    {
        playerUnit.Heal(5); // Heilt den player um einen Wert

        // Update UI
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel renewed strenght!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());


    }

    public void OnAttackButton() // Verweis Methode für den UI Button
    {
        if (state != BattleState.PLAYERTURN) // Wenn Player nicht an der Reihe ist, dann Methode nicht ausführen?
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}
