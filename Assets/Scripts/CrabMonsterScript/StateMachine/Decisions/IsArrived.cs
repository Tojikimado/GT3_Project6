using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/Decisions/IsArrived", fileName = "Is Arrived")]
public class IsArrived : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        //Debug.Log($"Distance to target {(state.transform.position - state.m_NavMesh.destination).sqrMagnitude} // Radius Acceptance = {state.m_MovementData.DestinationRadius * state.m_MovementData.DestinationRadius}");
        //Debug.Log($"Is Arrived {(state.transform.position - state.m_NavMesh.destination).sqrMagnitude<=state.m_MovementData.DestinationRadius * state.m_MovementData.DestinationRadius}");
        return (state.transform.position - state.m_NavMesh.destination).sqrMagnitude <= state.m_MovementData.DestinationRadius*state.m_MovementData.DestinationRadius;
    }
}
