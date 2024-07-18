using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("musicVolume")) {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }

}
