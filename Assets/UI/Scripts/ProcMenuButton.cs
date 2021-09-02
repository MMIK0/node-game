using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcMenuButton : MonoBehaviour
{
    public void ProcEvent()
    {
        UIManager.instance.CloseMenu();
        UIManager.instance.OpenMenu(UIManager.menuType.eventMenu);
    }

    public void EventHappens()
    {
        TargetNode node = UIManager.instance.currentNode;
        bool result = node.nodeEvent.DiceRoll(node.nodeEvent.stat, node.nodeEvent.enemyAdvantage);
        /*if (result == true)
        {
            UIManager.instance.CloseMenu();
            UIManager.instance.OpenMenu(UIManager.menuType.rewardMenu);
        }*/
    }

    public void Close()
    {
        UIManager.instance.CloseMenu();
        Player.instance.canMove = true;
    }
}
