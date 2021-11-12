using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public UIManager.menuType menuType;
    public void Awake()
    {
        UIManager.instance.RegisterMenu(menuType, gameObject);
        if (menuType != UIManager.menuType.mainMenu)
            gameObject.SetActive(false);
        else
            UIManager.instance.ActiveMenu = gameObject;
    }
}
