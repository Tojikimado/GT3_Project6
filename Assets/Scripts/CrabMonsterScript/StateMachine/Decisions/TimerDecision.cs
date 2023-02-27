using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Stay ", menuName = "CrabSM/Decisions/Limited Time")]
public class TimerDecision : CrabDecision
{
    [SerializeField]
    [Range(0.01f, 60f)]
    private float _MaximumStateDuraction = 1;

    public override bool Decide(CrabBaseStateMachine state)
    {
        return _MaximumStateDuraction < state.TimeSinceInState;
    }
}
