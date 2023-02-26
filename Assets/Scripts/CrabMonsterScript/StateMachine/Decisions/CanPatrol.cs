using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/Decisions/CanPatrol", fileName = "HasPatrolPoints")]
public class CanPatrol : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_Vision.HasPatrolPoints;
    }
}