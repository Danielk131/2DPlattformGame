using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SettingsEvents : MonoBehaviour
{
    private UIDocument _document;
    private Slider _slider;
    private Button _button;
    private List<Slider> _settingsSliders = new List<Slider>();
    [SerializeField] private AudioSource _audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        _document = GetComponent<UIDocument>();
        _slider = _document.rootVisualElement.Q("MusicSlider") as Slider;
        _slider.RegisterValueChangedCallback(SliderEvent);

        _button = _document.rootVisualElement.Q("Exit") as Button;
        _button.RegisterCallback<ClickEvent>(ExitToMainMenu);
        
    }

    private void ExitToMainMenu(ClickEvent evt)
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
    }


    private void SliderEvent(ChangeEvent<float> slider)
    {
        Debug.Log(slider.newValue);
        //_audioSource.volume = slider.newValue/100f;
        AudioListener.volume = slider.newValue / 100f;
        PlayerPrefs.SetFloat("musicVolume", slider.newValue/100f);

        
    }

    private void LoadVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        
    }
}
