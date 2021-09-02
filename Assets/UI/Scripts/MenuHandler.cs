using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public UIManager.menuType menuType;
    public void Awake()
    {
        UIManager.instance.RegisterMenu(menuType, gameObject);
        gameObject.SetActive(false);
    }
}
