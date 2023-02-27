using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Seek For Player", fileName = "Seek for Player")]
public class Seekingfor : SimplePatrol
{
    [SerializeField]
    [Range(0f, 5f)]
    private float _TauntingTime = 1.0f;
    private float _TauntingTimeCounter = 0f;

    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Intimidate_Unbend);
    }
    protected override void OnDestinationArrived(CrabBaseStateMachine Machine)
    {
        base.OnDestinationArrived(Machine);

        _TauntingTimeCounter = 0f;
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Intimidate_Unbend);
    }

    public override void PlayState(CrabBaseStateMachine Machine)
    {
        _TauntingTimeCounter += Time.deltaTime;
        if (_TauntingTimeCounter <= _TauntingTime) return;
        base.PlayState(Machine);
    }


}