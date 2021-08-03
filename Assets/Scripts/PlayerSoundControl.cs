using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundControl : MonoBehaviour
{

    [SerializeField] private AudioSource lightAudio;
    [SerializeField] private AudioSource jumpAudio;

    public void PlayJumpSound()
    {
        jumpAudio.PlayOneShot(jumpAudio.clip);
    }

    public void PlayLightSound()
    {
        lightAudio.PlayOneShot(lightAudio.clip);
    }

}
