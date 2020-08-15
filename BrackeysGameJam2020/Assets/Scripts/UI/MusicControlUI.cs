using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControlUI : MonoBehaviour
{
    private AudioSource AudioSrc;
    public Scrollbar scrollbar;

    private float AudioVolume = 1f;

    void Start()
    {
        AudioSrc = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        // Keep scroll value from the previous level.
        scrollbar.value = AudioSrc.volume;
    }

    void Update()
    {
        AudioSrc.volume = AudioVolume;
        SetVolume(scrollbar.value);
    }

    public void SetVolume(float vol)
    {
        AudioVolume = vol;
    }
}
