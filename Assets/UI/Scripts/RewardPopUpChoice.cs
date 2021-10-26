using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPopUpChoice : MonoBehaviour
{
    public void Replace()
    {
        UIManager.instance.CloseMenu();
        UIManager.instance.OpenMenu(UIManager.menuType.itemMenu);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Player.instance.currentItemInQueue = null;
        UIManager.instance.CloseMenu();
        gameObject.SetActive(false);
    }
}
