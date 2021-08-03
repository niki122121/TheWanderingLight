using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonBehaviour : MonoBehaviour
{

    [Header("Particles references")]

    [SerializeField] private ParticleSystem leftParticles;
    [SerializeField] private ParticleSystem rightParticles;
    [SerializeField] private ParticleSystem leftInstantParticles;
    [SerializeField] private ParticleSystem rightInstantParticles;

    private bool isOn;

    private void Start()
    {
        isOn = true;
    }

    public void PlayParticles()
    {
        if (isOn)
        {
            leftParticles.Play();
            rightParticles.Play();
        }
    }

    public void PlayInstantParticles()
    {
        if (isOn)
        {
            leftInstantParticles.Play();
            rightInstantParticles.Play();
            StopParticles();
            isOn = false;
        }
    }

    public void StopParticles()
    {
        if (isOn)
        {
            leftParticles.Stop();
            rightParticles.Stop();
        }
    }

}
