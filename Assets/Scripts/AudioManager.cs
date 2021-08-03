using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource audioHover;
    [SerializeField] private AudioSource audioClick;

    public void PlayHoverSound()
    {
        audioHover.PlayOneShot(audioHover.clip);
    }

    public void PlaySelectedSound()
    {
        audioClick.PlayOneShot(audioClick.clip);
    }

}
