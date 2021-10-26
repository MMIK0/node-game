using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagBackMenu : MonoBehaviour
{
    public List<MenuItem> menuItems = new List<MenuItem>();

    public void OnEnable()
    {
        FillBagBack();
    }

    public void FillBagBack()
    {
        Debug.Log("BackBackFilled");
        for (int i = 0; i < Player.instance.bagBack.Count; i++)
        {
            menuItems[i].currentItem = Player.instance.bagBack[i];
        }
    }
}
