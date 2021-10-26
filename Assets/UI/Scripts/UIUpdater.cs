using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
public class UIUpdater : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    public UiUpdate updateEvent;
    public bool shouldUpdate = false;
    public void OnEnable()
    {
        updateEvent.Invoke();
        UIManager.instance.battleEvent?.AddListener(UpdateBattleText);
        UIManager.instance.eventNodeTextEvent?.AddListener(UpdateEventText);
    }
    public void OnDisable()
    {
        UIManager.instance.battleEvent?.RemoveListener(UpdateBattleText);
        UIManager.instance.eventNodeTextEvent?.RemoveListener(UpdateEventText);
    }
    public void UpdateNodeText()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();

        tmp.text = NodeManager.instance.GetNodeText();
    }

    public void UpdateEventText()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();

        tmp.text = NodeManager.instance.GetEventText();
    }

    public void UpdateEventText(string eventText)
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();

        tmp.text = eventText;
    }

    private void UpdateBattleText(string battleText)
    {
        if(shouldUpdate == true)
        {
            tmp = GetComponentInChildren<TextMeshProUGUI>();
            tmp.text = battleText;
        }
    }

    public void UpdateImage()
    {
        GetComponent<Image>().sprite = NodeManager.instance.GetNodeImage();
    }
}
[System.Serializable]
public class UiUpdate : UnityEvent { }
