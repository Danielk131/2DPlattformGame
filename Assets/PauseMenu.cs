using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    [SerializeField] private UIDocument _document;
    private Button _button;
    private VisualElement _element;
    private bool gameIsPaused;
    // Start is called before the first frame update
   

    void Awake()
    {
        instance = this;
        _element = _document.rootVisualElement.Q("Container") as VisualElement;
        Debug.Log(_element.style.display.value);
        _button = _document.rootVisualElement.Q("PauseContinueButton") as Button;
        _button.RegisterCallback<ClickEvent>(ContinueGame);
        Debug.Log("Finner button? " + _button);
       /* _button = _document.rootVisualElement.Q("PauseSettingsButton") as Button;
        _button.RegisterCallback<ClickEvent>(PauseSettings);
        _button = _document.rootVisualElement.Q("PauseQuitButton") as Button;
        _button.RegisterCallback<ClickEvent>(PauseQuit);*/

    }

    private void PauseQuit(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void PauseSettings(ClickEvent evt)
    {
        throw new NotImplementedException();
    }

    private void ContinueGame(ClickEvent evt)
    {
        Debug.Log("Continue game");
        _element.style.display = DisplayStyle.None;

        Time.timeScale = 1f;
    }

    public void PauseButtonPressed()
    {
        if (gameIsPaused == true)
        {
            _element.style.display = DisplayStyle.None;
            gameIsPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
            _element.style.display = DisplayStyle.Flex;
            gameIsPaused = true;
            Time.timeScale = 0f;
        }
    }

  
    }

