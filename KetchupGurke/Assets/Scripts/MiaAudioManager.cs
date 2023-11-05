using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiaAudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip MiaFootstep;
    public AudioClip MiaRummage;
    public AudioClip MiaLoot;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void playMiaFootstepSound()
    {
        audioSource.clip = MiaFootstep;
        audioSource.Play();
    }

    public void playMiaRummageSound()
    {
        audioSource.clip = MiaRummage;
        audioSource.Play();
    }

    public void playMiaLootSound()
    {
        audioSource.clip = MiaLoot;
        audioSource.Play();
    }
}
