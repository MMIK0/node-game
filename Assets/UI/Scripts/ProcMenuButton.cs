using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcMenuButton : MonoBehaviour
{
    public void ProcEvent()
    {
        UIManager.instance.CloseMenu();
        UIManager.instance.OpenMenu(UIManager.menuType.eventMenu);
    }

    public void EventHappens()
    {
        gameObject.GetComponent<Button>().interactable = false;
        TargetNode node = UIManager.instance.currentNode;
        bool result = node.nodeEvent.DiceRoll(node.nodeEvent.stat, node.nodeEvent.enemyAdvantage);
        if (result == true)
        {
            StartCoroutine("EventWon");
        }
        else
            Debug.Log("No win :(");
    }

    public void Close()
    {
        UIManager.instance.CloseMenu();
        Player.instance.canMove = true;
    }

    private IEnumerator EventWon()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Button>().interactable = true;
        UIManager.instance.CloseMenu();
        UIManager.instance.OpenMenu(UIManager.menuType.rewardMenu);
    }
}
