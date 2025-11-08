using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainAudioSource;
    public AudioSource playerAudioSource;

    public AudioClip gameAudio;
    public AudioClip playerRunningAudio;

    void Start()
    {
        mainAudioSource.clip = gameAudio;
        // mainAudioSource.Play();
    }

    public void PlayerRunningSound()
    {
        playerAudioSource.clip = playerRunningAudio;
        playerAudioSource.loop = true;
        // playerAudioSource.Play();
    }

}

