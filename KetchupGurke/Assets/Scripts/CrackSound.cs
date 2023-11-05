using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSound : MonoBehaviour
{
    public AudioSource crackSoundSource;

    void PlayCrackSound()
    {
        crackSoundSource.enabled = true;
    }
}
