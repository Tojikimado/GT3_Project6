using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "CrabSM/Decisions/IsPlayerNear", fileName= "IsPlayerNear")]
public class IsPlayerNear : CrabDecision { 
    public override bool Decide(CrabBaseStateMachine state)
    {
        // Debug.Log($"Player in Zone {state.m_Vision.PlayerIsInZone}");
        return state.m_Vision.PlayerIsInZone;
    }
}
