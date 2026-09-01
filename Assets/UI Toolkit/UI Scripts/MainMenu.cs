using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private VisualElement _root;
    private Button _startButton;
    private Button _exitButton;

    private void OnEnable()
    {
        _startButton.clicked += StartGame;
        _startButton.RegisterCallback<ClickEvent>(ww);
        _startButton.RegisterCallback<ClickEvent>(ww);
    }
    private void Awake()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _startButton = _root.Q<Button>("Start");
        _exitButton = _root.Q<Button>("Exit");
    }

    private void ww(ClickEvent evt)
    {
        Debug.Log("www");
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void ExitGame()
    {
        Application.Quit();
    }    
}
