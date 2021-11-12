using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public Button button;

    public void OnEnable()
    {
        SaveManager.instance?.readyEvent.AddListener(SetButtonActive);
    }

    public void OnDisable()
    {
        SaveManager.instance?.readyEvent.RemoveListener(SetButtonActive);
    }

    public void Awake()
    {
        button = GetComponent<Button>();
    }

    private void SetButtonActive(bool result)
    {
        button.interactable = result;
    }

    public void TestClick()
    {
        SaveManager.instance.SaveStats();
        SceneManager.LoadScene(1);
    }    
}
