
using System;
using UnityEngine;
using UnityEngine.Audio;


/// <summary>
/// Plan B Reloaded v0.0.1
/// Port of 'Plan B' for the BBC Model B by Andrew Foord - Copyright 1987
/// AudioController.cs
/// Adapted from 'Learn to Code By Making a 2D Platformer in Unity'
/// by James Doyle
/// Adapted from '2D Platformer Sci-Fi Game in Unity'
/// by Aaron @ Thinkbot Labs
/// Created: 22/03/2019
/// </summary>

//
// modified 2020-08-04
//

// custom audio controller class
[Serializable]
public class Sound
{
    // Reference to AudioMixer group component
    public AudioMixerGroup audioMixerGroup;

    // Reference to AudioSource component
    private AudioSource audioSource;

    // Name of audio clip to play
    public string audioClipName;

    // Reference to audio clip
    public AudioClip audioClip;

    // Audio volume
    public float audioVolume;

    // Audio pitch
    public float audioPitch;

    // Loop audio
    public bool loopAudio;

    // Play audio clip on Awake
    public bool playOnAwake;


    // Set audio source
    public void SetAudioSource(AudioSource _audioSource)
    {
        // AudioSource
        audioSource = _audioSource;

        audioSource.clip = audioClip;

        audioSource.pitch = audioPitch;

        audioSource.volume = audioVolume;

        audioSource.playOnAwake = playOnAwake;

        audioSource.loop = loopAudio;

        // AudioMixer group
        audioSource.outputAudioMixerGroup = audioMixerGroup;
    }


    // Play audio
    public void PlayAudio()
    {
        audioSource.Play();
    }


    // stop audio
    public void StopAudio()
    {
        audioSource.Stop();
    }
}


public class AudioController : MonoBehaviour
{
    // reference to audio controller script
    public static AudioController instance;


    // create the singleton
    private void Awake()
    {
        CreateSingleton();
    }


    private void CreateSingleton()
    {
        // if the singleton instance already exists
        if (instance != null)
        {
            // then destroy the instance
            Destroy(gameObject);
        }

        // otherwise . . .
        else
        {
            // create the singleton instance
            instance = this;

            // and set to 'DontDestroyOnLoad'
            DontDestroyOnLoad(gameObject);
        }
    }


    // Reference to AudioMixer component
    public AudioMixer audioMixer;

    // Create an array for the audio clips
    [SerializeField] private Sound[] audioClipArray = null;


    private void Start()
    {
        // Loop through the audio clip array
        for (int audioClips = 0; audioClips < audioClipArray.Length; audioClips++)
        {
            // Create a game object for each audio clip
            GameObject audioClipGameObject = new GameObject("Audio Clip: " + audioClips + " " + audioClipArray[audioClips].audioClipName);

            // Parent the audio clips under the 'GameController' game object
            audioClipGameObject.transform.SetParent(this.transform);

            // Add an 'AudioSource' component to each of the audio clip game objects
            audioClipArray[audioClips].SetAudioSource(audioClipGameObject.AddComponent<AudioSource>());
        }
    }


    // Play audio clip
    public void PlayAudioClip(string _audioClipName)
    {
        // Loop through the audio clip array
        for (int audioClips = 0; audioClips < audioClipArray.Length; audioClips++)
        {
            // If we have found the audio clip to play
            if (audioClipArray[audioClips].audioClipName == _audioClipName)
            {
                // Play the audio clip
                audioClipArray[audioClips].PlayAudio();

                // And return
                return;
            }
        }

    }


    // stop audio
    public void StopAudioClip(string _audioClipName)
    {
        // Loop through the audio clip array
        for (int audioClips = 0; audioClips < audioClipArray.Length; audioClips++)
        {
            // If we have found the audio clip to play
            if (audioClipArray[audioClips].audioClipName == _audioClipName)
            {
                // Play the audio clip
                audioClipArray[audioClips].StopAudio();

                // And return
                return;
            }
        }
    }



    // Set Master volume
    public void SetMasterVolume(float masterVolumeLevel)
    {
        audioMixer.SetFloat("Master Volume Control", Mathf.Log10(masterVolumeLevel) * 20);
    }


    // Set Music volume
    public void SetMusicVolume(float musicVolumeLevel)
    {
        audioMixer.SetFloat("Music Volume Control", Mathf.Log10(musicVolumeLevel) * 20);
    }


    // Set SFX volume
    public void SetSFXVolume(float sfxVolumeLevel)
    {
        audioMixer.SetFloat("SFX Volume Control", Mathf.Log10(sfxVolumeLevel) * 20);
    }


} // End of class
