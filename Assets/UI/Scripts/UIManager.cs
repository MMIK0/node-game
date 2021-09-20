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
    public NodeInformation nodeInfo;
    public TargetNode currentNode;
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

    public string GetEventText()
    {
        TargetNode node = currentNode;
        return node.nodeEvent.eventText;
    }

    public string GetNodeText()
    {
        NodeInformation.Node node = nodeInfo.FindNode(currentNode.nodeId);
        if (currentNode.nodeId != 0)
            return node.text;
        else
            return null;
    }

    public Sprite GetNodeImage()
    {
        NodeInformation.Node node = nodeInfo.FindNode(currentNode.nodeId);
        if (currentNode.nodeId != 0)
            return node.image;
        else
            return null;
    }

}

[System.Serializable]
public class StatusEvent : UnityEvent<bool> { }
[System.Serializable]
public class ItemInfoEvent : UnityEvent<ItemInformation.Item> { }
[System.Serializable]
public class BattleEvent : UnityEvent<string> { }
