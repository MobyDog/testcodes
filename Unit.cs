using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Öffentliche Variablen für Spielereigenschaften
    public string unitName; 
    public int unitLevel;
    public int damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int dmg) // Damage Funktion/Methode mit bool Rückgabewert
    {
        currentHP -= dmg; // "dmg" Menge von aktueller HP abziehen

        if (currentHP <= 0) // Wenn aktuelle HP kleiner oder gleich 0 sind, dann Rückgabewert bool true, sonst false
            return true;
        else
            return false;
    }

    public void Heal(int amount) // Öffentliche Methode Heal mit int Parameter (amount ist die Variable)
    {
        currentHP += amount; // Aktuelle HP um die Menge der Variable "amount" erhöhen
        if (currentHP > maxHP) // Wenn aktuelle HP größer als die maximale HP wird, dann setze die HP zurück auf maxHP
            currentHP = maxHP;
    }
}
