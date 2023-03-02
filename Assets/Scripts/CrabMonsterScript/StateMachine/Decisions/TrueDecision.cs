using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "True", menuName = "CrabSM/Decisions/Always True")]
public class TrueDecision : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return true;
    }
}