using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabParticles : MonoBehaviour
{
    [SerializeField]
    private Transform _BloodParticulesParent;

    private ParticleSystem[] _BloodParticules;
    public ParticleSystem[] m_BloodParticules { get {return _BloodParticules; } }

    private void Awake()
    {
        _BloodParticules = _BloodParticulesParent.GetComponentsInChildren<ParticleSystem>();
    }

    public void PlayBloodParticules()
    {
        foreach (ParticleSystem bloodParticule in _BloodParticules) { bloodParticule.Play(); }
    }
}
