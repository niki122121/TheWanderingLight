using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [Header("Light variables")]
    [SerializeField] protected float maxIntensity;
    [SerializeField] protected float minIntensity;
    [SerializeField] protected float changeVelocity;
    [SerializeField] protected float losingVelocity;
    protected bool isOn;

    [Space]

    [Header("Light reference")]
    [SerializeField] protected Light _light;

    [Space]

    [Header("Components references")]
    [SerializeField] protected SpriteRenderer spr;

    [Space]

    [Header("Gameobjects references")]
    [SerializeField] protected GameObject particlesPrefab;
    [SerializeField] protected GameObject lightSpawner;

    private void Start()
    {
        isOn = true;

    }

    private void Update()
    {
        spr.transform.localScale = new Vector3(_light.intensity / 3, _light.intensity / 3, 0);

        if (isOn)
        {
            _light.range = Mathf.PingPong(Time.time * changeVelocity, maxIntensity - minIntensity) + minIntensity;
        }
        else
        {
            _light.intensity -= Mathf.Clamp(Time.deltaTime * losingVelocity, 0, Mathf.Infinity);
            if (_light.intensity == 0)
            {
                GameObject ls = Instantiate(lightSpawner, transform.position, new Quaternion(0, 0, 0, 0));
                ls.GetComponent<LightSpawner>().SetType(GetType());
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isOn)
        {
            Behaviour(other.gameObject);
            isOn = false;

            Vector3 particlesPos = transform.position;
            particlesPos.z = -0.9f;
            Instantiate(particlesPrefab, particlesPos, new Quaternion(0, 0, 0, 0));
        }
    }

    protected virtual void Behaviour(GameObject player)
    {

    }

    protected virtual int GetType()
    {
        return -1;
    }

}
