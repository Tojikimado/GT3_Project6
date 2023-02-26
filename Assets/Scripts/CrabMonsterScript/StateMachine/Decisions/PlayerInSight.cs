using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CrabSM/Decisions/PlayerInSight", fileName = "IsInSight")]
public class PlayerInSight : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_Vision.PlayerIsInSight;
    }
}
