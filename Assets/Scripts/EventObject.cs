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
        public ItemInformation itemInfo;
        public EventActions eventAction;

        public ItemInformation.Item GetRandomItem()
        { 
            return itemInfo.items[Random.Range(0, itemInfo.items.Count)];
        }

        public ItemInformation.Item GetRandomCommonItem()
        {
            foreach (ItemInformation.Item item in itemInfo.items)
            {
                List<ItemInformation.Item> itemsList = new List<ItemInformation.Item>();

                if (item.rarity == ItemInformation.Item.Rarity.common)
                    itemsList.Add(item);

                return itemsList[Random.Range(0, itemsList.Count)];
            }
            return null;
        }

        public ItemInformation.Item GetRandomRareItem()
        {

            foreach (ItemInformation.Item item in itemInfo.items)
            {
                if (item.rarity == ItemInformation.Item.Rarity.rare)
                {
                    return itemInfo.items[Random.Range(0, itemInfo.items.Count)];
                }
            }
            return null;
        }

        public ItemInformation.Item GetLegendaryItem(ItemInformation.Item.LegendaryItems itemToGet)
        {
            Debug.Log(itemToGet);

            for (int i = 0; i < itemInfo.items.Count; i++)
            {
                if (itemInfo.items[i].legendaryStatus == itemToGet)
                {
                    Debug.Log("We found" + itemInfo.items[i].legendaryStatus);
                    return itemInfo.items[i];
                }
            }
            return null;
        }

        public bool DiceRoll(Player.StatType statToCheck, int enemyAdvantage)
        {
            int friendlyStat;

            if (statToCheck != Player.StatType.none)
                friendlyStat = Player.instance.GetStat(statToCheck).statValue;
            else
                friendlyStat = 0;

            //Debug.Log(friendlyStat);

            int friendlyRoll = Random.Range(1, 7);
            int enemyRoll = Random.Range(1, 7);

            if (friendlyRoll + friendlyStat > enemyRoll + enemyAdvantage)
            {
                UIManager.instance.battleEvent.Invoke("Friendly Roll =" + " " + friendlyRoll + " + " + friendlyStat + " = " + (friendlyRoll + friendlyStat) + "\n" + "Enemy Roll =" + " " + enemyRoll + " + " + enemyAdvantage + " = " + (enemyRoll + enemyAdvantage) + "\n" + "You won!");
                Debug.Log("Moi joonas");
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
