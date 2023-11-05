using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefAudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip ThiefFootstep;
    public AudioClip ThiefRummage;
    public AudioClip ThiefLoot;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playThiefFootstepSound()
    {
        audioSource.clip = ThiefFootstep;
        audioSource.Play();
    }

    public void playThiefRummageSound()
    {
        audioSource.clip = ThiefRummage;
        audioSource.Play();
    }

    public void playThiefLootSound()
    {
        audioSource.clip = ThiefLoot;
        audioSource.Play();
    }
}
