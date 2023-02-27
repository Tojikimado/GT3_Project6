using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Eat", fileName = "Simple Eat")]
public class Eat : CrabBaseState
{
    [SerializeField]
    [Range(1f, 6f)]
    private float _EatingParticulesDelay = 1.37f;

    private float _TimeCounter;

    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Eat);
    }
    public override void PlayState(CrabBaseStateMachine Machine)
    {
        _TimeCounter += Time.deltaTime;
        if (_TimeCounter> _EatingParticulesDelay)
        {
            _TimeCounter = 0;
            Machine.m_CrabParticule.PlayBloodParticules();
            Machine.m_AudioManager.PlayRandomEatingSound();
        }
        base.PlayState(Machine);
    }
}
