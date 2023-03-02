using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inversed ", menuName = "CrabSM/Decisions/Inverse Decision")]
public class InverseDecision : CrabDecision
{
    [SerializeField]
    private CrabDecision _InversedDecision;
    public override bool Decide(CrabBaseStateMachine state)
    {
        //Debug.Log($"Distance to target {(state.transform.position - state.m_NavMesh.destination).sqrMagnitude} // Radius Acceptance = {state.m_MovementData.DestinationRadius * state.m_MovementData.DestinationRadius}");
        //Debug.Log($"Is Arrived {(state.transform.position - state.m_NavMesh.destination).sqrMagnitude<=state.m_MovementData.DestinationRadius * state.m_MovementData.DestinationRadius}");
        return !_InversedDecision.Decide(state);
    }
}