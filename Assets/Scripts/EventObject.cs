using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EventSpecs")]
public class EventObject : ScriptableObject
{
    public List<NodeEvent> eventList = new List<NodeEvent>();

    [System.Serializable]
    public class NodeEvent
    {
        public EventTypes eventTypes;
        public string eventText;
        public int enemyAdvantage;
        public ItemInformation itemInfo;
        public Player.StatType stat;

        public enum EventTypes
        {
            loot,
            money,
        }

        public ItemInformation.Item GetRandomItem()
        {
            return itemInfo.items[Random.Range(0, itemInfo.items.Count)];
        }

        public bool DiceRoll(Player.StatType statToCheck, int enemyAdvantage)
        {
            int friendlyStat = Player.instance.GetStat(statToCheck).statValue;
            Debug.Log(friendlyStat);

            int friendlyRoll = Random.Range(1, 7);
            int enemyRoll = Random.Range(1, 7);

            if (friendlyRoll + friendlyStat > enemyRoll + enemyAdvantage)
            {
                UIManager.instance.battleEvent.Invoke("Friendly Roll =" + " " + friendlyRoll + " + " + friendlyStat + " = " + (friendlyRoll + friendlyStat) + "\n" + "Enemy Roll =" + " " + enemyRoll + " + " + enemyAdvantage + " = " + (enemyRoll + enemyAdvantage) + "\n" + "You won!");
                Debug.Log("You won! ");
                return true;
            }
            else
            {
                UIManager.instance.battleEvent.Invoke("Friendly Roll =" + " " + friendlyRoll + " + " + friendlyStat + " = " + (friendlyRoll + friendlyStat) + "\n" + "Enemy Roll =" + " " + enemyRoll + " + " + enemyAdvantage + " = " + (enemyRoll + enemyAdvantage) + "\n" + "You lost!");
                Debug.Log("You lost, back to gulag :( ");
                return false;
            }
        }
    }
}
