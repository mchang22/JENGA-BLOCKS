using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public AudioClip StartSound;
    public AudioClip[] ComboSound;

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        //New feature
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStartSound()
    {
        audioSource.clip = StartSound;
        audioSource.Play();
    }

    public void PlayComboSound(int combo)
    {
        if (combo <= 8)
            audioSource.clip = ComboSound[combo - 1];
        else
            audioSource.clip = ComboSound[7];

        audioSource.Play();
    }
}
