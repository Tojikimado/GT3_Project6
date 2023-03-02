using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Intimidate", fileName = "Intimidate")]
public class Intimidate : CrabBaseState
{
    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_NavMesh.destination = Machine.transform.position;
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Intimidate_CloseUp);
    }
}
