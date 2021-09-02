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
    }
    public void OnDisable()
    {
        UIManager.instance.battleEvent?.RemoveListener(UpdateBattleText);
    }
    public void UpdateNodeText()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();

        tmp.text = UIManager.instance.GetNodeText();
    }

    public void UpdateEventText()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();

        tmp.text = UIManager.instance.GetEventText();
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
        GetComponent<Image>().sprite = UIManager.instance.GetNodeImage();
    }
}
[System.Serializable]
public class UiUpdate : UnityEvent { }
