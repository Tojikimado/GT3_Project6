using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/Decisions/IsInRange", fileName = "IsInRange")]
public class IsArrived : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return (state.transform.position - state.m_NavMesh.destination).sqrMagnitude <= state.m_MovementData.DestinationRadius*state.m_MovementData.DestinationRadius;
    }
}
