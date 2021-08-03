using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private bool musicOn;
    [SerializeField] private AudioSource menuHover;
    [SerializeField] private AudioSource menuSelected;
    [SerializeField] private AudioSource walking;
    [SerializeField] private AudioSource light;
    [SerializeField] private AudioSource die;
    [SerializeField] private AudioSource jumping;
    [SerializeField] private AudioSource music;

    private void Start()
    {
        if (musicOn)
            music.Play();
    }

    public void PlayMenuHover()
    {
        menuHover.Play();
    }

    public void PlayMenuSelected()
    {
        menuSelected.Play();
    }

    public void PlayWalkingSound()
    {
        walking.Play();
    }

    public void PlayLightSound()
    {
        light.Play();
    }

    public void PlayDieSound()
    {
        die.Play();
    }

    public void PlayJumpingSound()
    {
        jumping.Play();
    }

}
