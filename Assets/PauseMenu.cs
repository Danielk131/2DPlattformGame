using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private UIDocument _document;
    private Button _button;
    private bool gameIsPaused;
    // Start is called before the first frame update
   

    void start()
    {
        _document = GetComponent<UIDocument>();
        _button = _document.rootVisualElement.Q("PauseContinueButton") as Button;
        _button.RegisterCallback<ClickEvent>(ContinueGame);
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
        _document.enabled = false;
        Time.timeScale = 1f;
    }

  
    }

