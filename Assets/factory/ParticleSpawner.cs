using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    public GameObject _particleSystem;
    public float _lifetime;

    private SphereManager _sphereManager;

    private void Start()
    {
        _sphereManager = GetComponent<SphereManager>();
        _sphereManager.OnSphereDestroyByPlayer += OnSphereClickByPlayer;
        _lifetime = _particleSystem.GetComponent<ParticleSystem>().main.duration;
    }

    public void OnSphereClickByPlayer(SphereData sphereData)
    {
        var buf = Instantiate(_particleSystem, sphereData.SphereTransform.position, sphereData.SphereTransform.rotation);
        buf.GetComponent<ParticleSystemRenderer>().material = sphereData.Material;
        buf.GetComponent<ParticleSystem>().Play();
        Destroy(buf, _lifetime);
    }
}
