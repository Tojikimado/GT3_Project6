using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Chase Player", fileName = "Chase Player")]
public class ChasePlayer : SimplePatrol
{

    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        _PatrolPoint = Machine.m_Vision.PlayerTransform;
    }

    public override void PlayState(CrabBaseStateMachine Machine)
    {
        if (_PatrolPoint == null)
        {
            _PatrolPoint= Machine.m_Vision.PlayerTransform;
        }
        base.PlayState(Machine);
    }

    protected override void SetPatrolAnim(CrabBaseStateMachine Machine)
    {
        _PatrolAnim = Machine.m_Animation.AnimationsData.Walk_Fast;
    }
}