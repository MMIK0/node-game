using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemInfoText : MonoBehaviour
{
    public typeList type;

    public void OnEnable()
    {
        UIManager.instance.itemTextUpdate.AddListener(TextUpdate);
    }
    public void OnDisable()
    {
        UIManager.instance.itemTextUpdate.RemoveListener(TextUpdate);
    }

    public void TextUpdate(ItemInformation.Item item)
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();

        if (type == typeList.itemName)
            text.text = item.name;
        else if (type == typeList.itemStat)
            text.text = item.statType.ToString();
        else
            text.text = item.statAmount.ToString();
    }

    public enum typeList
    {
        itemName,
        itemStat,
        itemStatAmount,
    }

}
