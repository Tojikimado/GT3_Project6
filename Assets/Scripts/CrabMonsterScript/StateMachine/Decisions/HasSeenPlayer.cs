using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CrabSM/Decisions/HasSeenPlayer", fileName = "HasSeenPlayer")]
public class HasSeenPlayer : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_Vision.HasCrabSeenThePlayer();
    }
}
