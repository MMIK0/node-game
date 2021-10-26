using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcMenuButton : MonoBehaviour
{
    public void ProcEvent()
    {
        if (NodeManager.instance.currentNode.nodeEvent.eventAction != null)
            NodeManager.instance.currentNode.nodeEvent.eventAction.action.SetUpUI();
        else
            Debug.Log("It was null?");
    }

    public void Close()
    {
        UIManager.instance.CloseMenu();
        Player.instance.canMove = true;
    }
}
