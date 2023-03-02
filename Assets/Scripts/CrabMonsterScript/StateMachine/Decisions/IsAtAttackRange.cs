using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/Decisions/IsAtAttackRange", fileName="IsAtAttackRange")]
public class IsAtAttackRange : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        //Debug.Log($"Distance to target {(state.transform.position - state.m_NavMesh.destination).sqrMagnitude} // Radius Acceptance = {state.m_MovementData.DestinationRadius * state.m_MovementData.DestinationRadius}");
        //Debug.Log($"Is Arrived {(state.transform.position - state.m_NavMesh.destination).sqrMagnitude<=state.m_MovementData.DestinationRadius * state.m_MovementData.DestinationRadius}");
        return (state.transform.position - state.m_Vision.PlayerTransform.position).sqrMagnitude <= state.m_Vision.AttackRange * state.m_Vision.AttackRange;
    }
}