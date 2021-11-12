using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player instance;
    [HideInInspector]
    public bool canMove;
    public List<Stat> statsList = new List<Stat>();
    public List<ItemInformation.Item> bagBack = new List<ItemInformation.Item>();
    public ItemInformation.Item currentItemInQueue = null;
    public NavMeshAgent agent;

    public void Awake()
    {
        statsList.Add(new Stat(StatType.strength, PlayerPrefs.GetInt("str")));
        statsList.Add(new Stat(StatType.charisma, PlayerPrefs.GetInt("chari")));
        statsList.Add(new Stat(StatType.battlePower, PlayerPrefs.GetInt("bp")));
        statsList.Add(new Stat(StatType.tecnowledge, PlayerPrefs.GetInt("tec")));
        statsList.Add(new Stat(StatType.health, PlayerPrefs.GetInt("hp")));
        statsList.Add(new Stat(StatType.money, PlayerPrefs.GetInt("money")));
    }

    public void OnEnable()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.Log("Killing Duplicate Manager");
            Destroy(gameObject);
            return;
        }

        canMove = true;
    }

    public void MovePlayer(TargetNode nodeToMove)
    {
        if (canMove)
            agent.isStopped = false;

        agent.SetDestination(nodeToMove.transform.position);
    }
    
    public Stat GetStat(StatType statType)
    {
        foreach(Stat stat in statsList)
        {
            if (stat.statType == statType)
                return stat;
        }
        return null;
    }

    public ItemInformation.Item GetItemFromBag()
    {
        ItemInformation.Item item = bagBack[0];
        return item;
    }

    public void AddItemToQueue(ItemInformation.Item itemToAdd)
    {
        currentItemInQueue = itemToAdd;
    }

    public void GiveItem(ItemInformation.Item item)
    {
        bagBack.Add(item);
        GetStat(item.statType).statValue += item.statAmount;
    }

    public void RemoveItem(ItemInformation.Item item)
    {
        bagBack.Remove(item);
        GetStat(item.statType).statValue -= item.statAmount;
    }

    public void GainHealth(int healthGain)
    {
        GetStat(StatType.health).statValue += healthGain;
        UIManager.instance.uiEvent?.Invoke();
    }
    public void LoseHealth(int healthLoss)
    {
        GetStat(StatType.health).statValue -= healthLoss;
        UIManager.instance.uiEvent?.Invoke();
    }

    public void HandleMoney(int moneyGain)
    {
        Stat stat = GetStat(StatType.money);
        stat.statValue += moneyGain;
        if (stat.statValue < 0)
            stat.statValue = 0;
        UIManager.instance.uiEvent?.Invoke();
    }

    public enum StatType
    {
        none,
        charisma,
        strength,
        tecnowledge,
        battlePower,
        health,
        money,
    }

    public class Stat
    {
        public StatType statType;
        public int statValue;

        public Stat(StatType stats, int value)
        {
            statType = stats;
            statValue = value;
        }
    }
}
