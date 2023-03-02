using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/TakeDamage", fileName = "Take Damage")]
public class TakeDamage : CrabBaseState
{
    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_NavMesh.destination = Machine.transform.position;
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.TakeDamage_Stun);
    }
}
