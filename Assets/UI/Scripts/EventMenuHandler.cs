using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EventMenuHandler : MonoBehaviour
{
    public TextMeshProUGUI eventText, battleText;
    public Image eventImage;
    public Button forward, quit;

    private void OnEnable()
    {
        forward.gameObject.SetActive(true);
        quit.gameObject.SetActive(false);
    }
}
