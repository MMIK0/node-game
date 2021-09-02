using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RewardMenuHandler : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI tmp;

    public void OnEnable()
    {
        GetReward();
    }

    public void GetReward()
    {
        TargetNode node = UIManager.instance.currentNode;
        ItemInformation.Item item = node.nodeEvent.GetRandomItem();
        Debug.Log(item.name + " " + item.description);
        if (Player.instance.bagBack.Count < 4)
        {
            Player.instance.bagBack.Add(item);
            item.GiveStat(item.statType, item.statAmount);
            RewardActivate(item);
        }
        else
        {
            Debug.Log("Didnt add");

        }
        UIManager.instance.uiEvent.Invoke();
    }

    public void AddOrRemove(ItemInformation.Item item)
    {
        Debug.Log("Please select an item to remove");
        List<ItemInformation.Item> itemlist = new List<ItemInformation.Item>();
        itemlist.Add(item);
        UIManager.instance.OpenMenu(UIManager.menuType.itemMenu);
    }

    public void RewardActivate(ItemInformation.Item item)
    {
        image.sprite = item.icon;
        tmp.text = item.statType.ToString() + " " + item.statAmount.ToString();
    }
}
