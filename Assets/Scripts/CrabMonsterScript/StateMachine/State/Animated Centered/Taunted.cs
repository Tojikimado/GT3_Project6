using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Taunted", fileName = "Simple Taunt")]
public class Taunted : CrabBaseState
{
    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_NavMesh.destination = Machine.transform.position;
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Intimidate_Taunt);
        int random = Random.Range(0, 2);
        if (random == 0)
            Machine.m_AudioManager.Play("Grunt");
    }
}
