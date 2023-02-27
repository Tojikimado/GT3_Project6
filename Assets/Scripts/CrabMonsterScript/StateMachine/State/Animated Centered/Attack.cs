using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Attack", fileName = "Simple Attack")]
public class Attack : CrabBaseState
{
    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_Animation.SetAnim(Machine.m_Animation.AnimationsData.GetRandomAttackAnim());
    }
}
