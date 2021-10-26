using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RewardMenuHandler : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI tmp;
    public GameObject rewardMenuPopUp;
    public Button quit;

    public void OnEnable()
    {
        GetItem();
        quit.interactable = true;
    }

    public void GetItem()
    {
        ItemInformation.Item itemToGive = NodeManager.instance.currentItem;

        RewardActivate(itemToGive);
        if (Player.instance.bagBack.Count < 4)
        {
            Player.instance.GiveItem(itemToGive);
        }
        else
        {
            quit.interactable = false;
            AddOrRemove(itemToGive);
        }

        UIManager.instance.uiEvent.Invoke();
    }

    public void AddOrRemove(ItemInformation.Item item)
    {
        Player.instance.AddItemToQueue(item);
        rewardMenuPopUp.SetActive(true);
    }

    public void RewardActivate(ItemInformation.Item item)
    {
        image.sprite = item.icon;
        tmp.text = item.statType.ToString() + " " + item.statAmount.ToString();
    }
}
