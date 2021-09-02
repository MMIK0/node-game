using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWantedMenu : MonoBehaviour
{
    public UIManager.menuType menutype;

    public void OpenMenu()
    {
        UIManager.instance.OpenMenu(menutype);
    }
}
