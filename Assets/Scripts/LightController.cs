using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    [Header("Lights variables")]
    [SerializeField] private float maxIntensity;
    [SerializeField] private float lossIntensityVelocity;
    [SerializeField] private float gainIntensityVelocity;
    private float currentIntensity = 20;
    private float lightGain;
    private bool isRecovering;

    [Space]

    [Header("Gameobjects references")]
    [SerializeField] private Light _light;
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private GameObject trailParticles;

    private LedController lc;

    private void Start()
    {
        lightGain = 0;
        isRecovering = false;
        _light.range = currentIntensity;
        lc = GameObject.Find("Uduino").GetComponent<LedController>();
        lc.GetLightWhite();
    }

    private void Update()
    {
        if (!isRecovering && lightGain >= 0)
            currentIntensity -= Time.deltaTime * lossIntensityVelocity;
        
        float newGain = Mathf.Sign(lightGain) * Mathf.Min(Time.deltaTime * gainIntensityVelocity, Mathf.Abs(lightGain));
        lightGain -= newGain;
        currentIntensity += newGain;

        if (currentIntensity < 1)
        {
            KillPlayer();
        }

        Mathf.Clamp(currentIntensity, 0, maxIntensity);

        _light.range = currentIntensity;

    }
    
    public void GainLight(float newGain)
    {
        lightGain += newGain;
    }
    
    private void KillPlayer()
    {
        Vector3 deathPos = transform.position;
        deathPos.z = -0.5f;
        Instantiate(deathParticles, deathPos, new Quaternion(0, 0, 0, 0));
        trailParticles.transform.parent = null;
        _light.transform.parent = null;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            KillPlayer();
        if (other.CompareTag("CollectableLight"))
            GetComponent<PlayerSoundControl>().PlayLightSound();
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("WallRecovery"))
        {
            isRecovering = true;
            lightGain = maxIntensity - currentIntensity;
            lc.GetLightWhite();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("WallRecovery"))
        {
            isRecovering = false;
        }
    }

}
