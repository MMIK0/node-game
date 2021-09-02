using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [HideInInspector]
    public bool canMove;
    private Transform realPos;

    public List<Stat> statsList = new List<Stat>();
    public List<ItemInformation.Item> bagBack = new List<ItemInformation.Item>();

    public void Awake()
    {
        statsList.Add(new Stat(StatType.strength, 3));
        statsList.Add(new Stat(StatType.charisma, 3));
        statsList.Add(new Stat(StatType.battlePower, 3));
        statsList.Add(new Stat(StatType.tecnowledge, 3));
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
        realPos = transform;
    }

    public void MovePlayer(TargetNode nodeToMove)
    {
        realPos.position = nodeToMove.transform.position;
        transform.position = new Vector3(realPos.position.x, realPos.position.y + 1f, realPos.position.z);
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

    public void RemoveItem(ItemInformation.Item item)
    {
        Debug.Log(bagBack.Count);
        bagBack.Remove(item);
        Debug.Log(bagBack.Count);
    }

    public enum StatType
    {
        charisma,
        strength,
        tecnowledge,
        battlePower,
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
