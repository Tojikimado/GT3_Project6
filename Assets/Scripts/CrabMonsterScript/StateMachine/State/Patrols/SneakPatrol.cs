using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Sneek Patrol", fileName = "Sneek Patrol")]
public class SneakPatrol : SimplePatrol
{
    protected override void SetPatrolAnim(CrabBaseStateMachine Machine)
    {
        _PatrolAnim = Machine.m_Animation.AnimationsData.Walk_Sneak;
    }

}