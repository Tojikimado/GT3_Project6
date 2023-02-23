using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CrabTransitions : MonoBehaviour
{
    public CrabDecision Decision;
    public CrabBaseState TrueState;
    public CrabBaseState FalseState;

    public void Execute(CrabBaseStateMachine CrabSM)
    {
        if (Decision.Decide(CrabSM) && !(TrueState))
            CrabSM.ChangeState(TrueState);
        else if (true)
            CrabSM.ChangeState(FalseState);
    }
}
