using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterStats : MonoBehaviour
{
    public Image characterImage;
    public int charisma, strength, tecnowledge, battlePower, health, money;
    public string desc;
    public TextMeshProUGUI textObject;

    public void OnMouseDown()
    {
        Debug.Log("Yep");
        textObject.text = desc;
        SaveManager.instance.SaveValues(charisma, strength, tecnowledge, battlePower, health, money);
        SaveManager.instance.readyEvent.Invoke(true);
    }
}
