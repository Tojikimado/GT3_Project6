using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="CrabSM/Decisions/IsInRange", fileName="IsInRange")]
public class IsNearPlayer : CrabDecision { 
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_Vision.PlayerIsInRange;
    }
}
