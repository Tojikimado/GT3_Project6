using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/Decisions/CannotFinishPath", fileName = "CannotFinishPath")]
public class CannotFinishPath : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_NavMesh.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathPartial;
    }
}