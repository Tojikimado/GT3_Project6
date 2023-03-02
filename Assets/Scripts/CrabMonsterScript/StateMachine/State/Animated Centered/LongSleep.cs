using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Sleep", fileName = "Simple Sleep")]
public class LongSleep : CrabBaseState
{
    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_NavMesh.destination = Machine.transform.position;
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Sleep);
    }
    public override void OnExitState(CrabBaseStateMachine Machine)
    {
        base.OnExitState(Machine);
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Intimidate_Taunt);
    }
}