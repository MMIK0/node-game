using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [HideInInspector]
    public StatusEvent OnMenuStatusChanged;
    public ItemInfoEvent itemTextUpdate;
    public UnityEvent uiEvent;
    public BattleEvent battleEvent;
    public NodeTextEvent eventNodeTextEvent;
    public Dictionary<menuType, GameObject> menus = new Dictionary<menuType, GameObject>();
    public GameObject ActiveMenu;

    public enum menuType
    {
        NodeMenu,
        itemMenu,
        rewardMenu,
        eventMenu,
    }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.Log("Killing Duplicate Manager");
            Destroy(gameObject);
            return;
        }
        Debug.Log(instance);
    }

    public void RegisterMenu(menuType type, GameObject menu)
    {
        menus.Add(type, menu);
    }

    public void OpenMenu(menuType type)
    {
        GameObject menu;
        menus.TryGetValue(type, out menu);
        Debug.Log(menu);
        menu.SetActive(true);
        ActiveMenu = menu;
    }

    public void CloseMenu()
    {
        ActiveMenu.SetActive(false);
        ActiveMenu = null;
    }

    public GameObject GetMenu(menuType menuType)
    {
        GameObject menu;
        menus.TryGetValue(menuType, out menu);
        return menu;
    }
}

[System.Serializable]
public class StatusEvent : UnityEvent<bool> { }
[System.Serializable]
public class ItemInfoEvent : UnityEvent<ItemInformation.Item> { }
[System.Serializable]
public class BattleEvent : UnityEvent<string> { }
[System.Serializable]
public class NodeTextEvent : UnityEvent<string> { }
