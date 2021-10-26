using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemSpecs")]
public class ItemInformation : ScriptableObject
{
    public List<Item> items = new List<Item>();

    [System.Serializable]
    public class Item
    {
        public string name, description;
        public Sprite icon;
        public Player.StatType statType;
        public int statAmount;
        public Rarity rarity;
        public LegendaryItems legendaryStatus;

        public enum Rarity
        {
            random,
            common,
            rare,
            legendary,
        }

        public enum LegendaryItems
        {
            none,
            hammerOfThor,
            ringOfUkko,
        }
    }
}
