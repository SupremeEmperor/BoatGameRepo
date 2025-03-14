using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    { 
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in game Object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform);

        //assign the audioClip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get length of clip
        float clipLength = audioSource.clip.length;

        //destroy after clip ends
        Destroy(audioSource.gameObject, clipLength);
    }
}
