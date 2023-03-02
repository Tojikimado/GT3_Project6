using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CrabSM/Decisions/IsPlayerMoving", fileName = "IsPlayerMoving")]
public class IsPlayerMoving : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_Vision.PlayerMovements.IsMoving;
    }
}

