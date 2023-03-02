using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CrabSM/Decisions/IsPlayerInSight", fileName = "IsInSight")]
public class IsPlayerInSight : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_Vision.PlayerIsInSight;
    }
}
