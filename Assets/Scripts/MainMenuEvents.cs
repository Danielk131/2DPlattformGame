using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;
    private List<Button> _menuButtons = new List<Button>();
    [SerializeField] private AudioSource _audioSource; 

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _button = _document.rootVisualElement.Q("StartGameButton") as Button;
        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);
        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();

        for(int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsCLick);
            Debug.Log("Registrerer lyd");
        }
    }

    private void OnAllButtonsCLick(ClickEvent evt)
    {
        _audioSource.Play();
        Debug.Log("Spill lyd");
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("Clicked event");
        SceneManager.LoadScene(1);
    }
    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }
}

