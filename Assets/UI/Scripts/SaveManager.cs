using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private int chari, str, tec, bp, hp, mon;
    public ReadyEvent readyEvent;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.Log("Killing Duplicate Manager");
            Destroy(gameObject);
            return;
        }
        Debug.Log(instance);
    }

    public void SaveValues(int charisma, int strength, int tecnowledge, int battlePower, int health, int money)
    {
        chari = charisma;
        str = strength;
        tec = tecnowledge;
        bp = battlePower;
        hp = health;
        mon = money;
    }

    public void Checkstats()
    {
        Debug.Log(chari + "" + str + "" + tec + "" + bp + "" + hp + "" + mon);
    }

    public void SaveStats()
    {
        PlayerPrefs.SetInt("chari", chari);
        PlayerPrefs.SetInt("str", str);
        PlayerPrefs.SetInt("tec", tec);
        PlayerPrefs.SetInt("bp", bp);
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("money", mon);
    }
}
[System.Serializable]
public class ReadyEvent : UnityEvent<bool> { }