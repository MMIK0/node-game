using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public ItemInformation.Item currentItem;
    public GameObject informationWindow;

    private void OnEnable()
    {
        GetComponent<Image>().sprite = currentItem.icon;
    }

    public void OnMouseEnter()
    {
        if (currentItem.name == "" || currentItem.name == null)
            return;

        Debug.Log(currentItem.name);
        informationWindow.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        informationWindow.SetActive(true);
        informationWindow.GetComponent<ItemInfoUi>().GetItemInfo(currentItem);
    }

    public void OnMouseDown()
    {
        if (currentItem.name == "")
            return;

        Player.instance.RemoveItem(currentItem);
        currentItem = new ItemInformation.Item();
        GetComponent<Image>().sprite = null;
        UIManager.instance.uiEvent?.Invoke();
        if (Player.instance.currentItemInQueue.statType != Player.StatType.none)
        {
            Debug.Log(Player.instance.currentItemInQueue);
            Player.instance.GiveItem(Player.instance.currentItemInQueue);
            currentItem = Player.instance.currentItemInQueue;
            GetComponent<Image>().sprite = Player.instance.currentItemInQueue.icon;
            UIManager.instance.uiEvent?.Invoke();
            Player.instance.currentItemInQueue = new ItemInformation.Item();
        }
    }

    public void OnMouseExit()
    {
        informationWindow.SetActive(false);
    }
}
