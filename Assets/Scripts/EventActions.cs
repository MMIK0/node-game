using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "EventActionSpecs")]
public class EventActions : ScriptableObject
{
    public enum EventTypes
    {
        loseHealth,
        gamble,
        getReward,
        handleMoney,
        story,
    }

    public EventAction action;

    [System.Serializable]
    public class EventAction
    {
        [Header("Event Fields")]
        public EventTypes eventType;
        public Player.StatType stat;
        public string eventText;
        public Sprite eventImage;
        [Header("Optional Stats")]
        public int enemyAdvantage;
        public int healthLoss;
        public int moneyChange;
        [Header("Item Fields")]
        public ItemInformation.Item.Rarity itemRarity;
        public ItemInformation.Item.LegendaryItems legendaryItems;
        [Space]
        public List<EventAction> FollowUpEvents = new List<EventAction>();
        private EventMenuHandler eventMenuHandler;
        private int nextMenu;

        public void GetNextEvent(int i)
        {
            if(FollowUpEvents.Count <= 0)
            {
                Debug.Log("Should End");
                EndEvent();
            }

            Debug.Log("We are settuping Ui");
            FollowUpEvents[i].SetUpUI();
        }

        public void SetUpUI()
        {
            UIManager.instance.CloseMenu();
            UIManager.instance.OpenMenu(UIManager.menuType.eventMenu);
            eventMenuHandler = UIManager.instance.GetMenu(UIManager.menuType.eventMenu).GetComponent<EventMenuHandler>();
            eventMenuHandler.eventText.text = eventText;
            eventMenuHandler.forward.onClick.RemoveAllListeners();
            eventMenuHandler.forward.onClick.AddListener(delegate { DoEvent(); });
            Debug.Log("We set up the UI");
        }

        public void DoEvent()
        {
            if (eventType == EventTypes.gamble)
            {
                eventMenuHandler.forward.onClick.RemoveAllListeners();
                eventMenuHandler.forward.onClick.AddListener(delegate { GetNextEvent(nextMenu); });
                Gamble();
            }
            else if (eventType == EventTypes.getReward)
                GetReward();
            else if (eventType == EventTypes.loseHealth)
                LoseHealth();
            else if (eventType == EventTypes.handleMoney)
                HandleMoney();
            else if (eventType == EventTypes.story)
                Story();
        }

        public void LoseHealth()
        {
            Player.instance.LoseHealth(healthLoss);
            EndEvent();
        }

        public void Gamble()
        {
            TargetNode node = NodeManager.instance.currentNode;
            bool result = node.nodeEvent.DiceRoll(stat, enemyAdvantage);
            Debug.Log(result);
            if (result == true)
                nextMenu = 0;
            else if (result == false)
                nextMenu = 1;
        }

        public void GetReward()
        {
            TargetNode node = NodeManager.instance.currentNode;
            ItemInformation.Item itemToGive;
            Debug.Log(itemRarity);

            if (itemRarity == ItemInformation.Item.Rarity.common)
                itemToGive = node.nodeEvent.GetRandomCommonItem();
            else if (itemRarity == ItemInformation.Item.Rarity.rare)
                itemToGive = node.nodeEvent.GetRandomRareItem();
            else if (itemRarity == ItemInformation.Item.Rarity.legendary)
                itemToGive = node.nodeEvent.GetLegendaryItem(legendaryItems);
            else
                itemToGive = node.nodeEvent.GetRandomItem();


            NodeManager.instance.currentItem = itemToGive;
            UIManager.instance.CloseMenu();
            UIManager.instance.OpenMenu(UIManager.menuType.rewardMenu);
        }

        public void EndEvent()
        {
            eventMenuHandler.forward.gameObject.SetActive(false);
            eventMenuHandler.quit.gameObject.SetActive(true);
        }

        public void HandleMoney()
        {
            Player.instance.HandleMoney(moneyChange);
            EndEvent();
        }

        public void Story()
        {
            nextMenu = 0;
            Debug.Log("I was achually called");
            GetNextEvent(nextMenu);
        }
    }
}