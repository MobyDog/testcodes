using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    //Öffentliche Variablen

    public Text nameText; 
    public Text levelText;
    public Slider hpSlider;

    public void SetHUD(Unit unit) // Öffentliche Methode ohne Rückgabewert, mit einer Variable von Typ Unit
    {
        nameText.text = unit.unitName; // Zuweisung des unit.unitName Wertes auf die (Text Ausgabe) Variable nameText.text
        levelText.text = "Lvl " + unit.unitLevel; // Müsste hier nicht ein Error kommen, weil man versucht einen Int Wert in Text (String) auszugeben?
        hpSlider.maxValue = unit.maxHP; // Was ist maxValue für ein Datentyp? (100% von 100% ?)
        hpSlider.value = unit.currentHP; // Dann wird value, einfach eine Abfrage vom aktuellen value Wert sein

    }

    public void SetHP(int hp)
    {
        // Für Abfrage von aktuellen HP mitten im Kapf
        hpSlider.value = hp;
    }




}
