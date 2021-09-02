using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatText : MonoBehaviour
{
    [SerializeField]
    private Player.StatType statType;
    private TextMeshProUGUI tmp;

    public void OnEnable()
    {
        UIManager.instance.uiEvent?.AddListener(UpdateStats);
    }

    public void OnDisable()
    {
        UIManager.instance.uiEvent?.RemoveListener(UpdateStats);
    }
    public void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        UpdateStats();
    }

    public void UpdateStats()
    {
        tmp.text = statType.ToString() + " " + Player.instance.GetStat(statType).statValue.ToString();
    }

}
