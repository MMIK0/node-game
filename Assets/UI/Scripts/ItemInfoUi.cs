using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoUi : MonoBehaviour
{
    public ItemInformation.Item currentItem;

    public void GetItemInfo(ItemInformation.Item item)
    {
        currentItem = item;
        UIManager.instance?.itemTextUpdate.Invoke(currentItem);
    }
}
