using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/Decisions/RandomChoice", fileName = "Random Decision")]
public class RandomDecision : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return state.m_Vision.PlayerIsInSight;
    }
}

