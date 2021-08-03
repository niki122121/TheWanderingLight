using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    [SerializeField] private AudioSource walk1Sound;
    [SerializeField] private AudioSource walk2Sound;
   
    public void PlayWalking1Sound()
    {
        walk1Sound.Play();
    }

    public void PlayWalking2Sound()
    {
        walk2Sound.Play();
    }
}
