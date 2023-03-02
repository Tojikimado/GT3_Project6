using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Sneak Chase Player", fileName = "Sneak Chase Player")]
public class SneakChasePlayer : ChasePlayer
{
    protected override void SetPatrolAnim(CrabBaseStateMachine Machine)
    {
        _PatrolAnim = Machine.m_Animation.AnimationsData.Walk_Sneak;
    }
}