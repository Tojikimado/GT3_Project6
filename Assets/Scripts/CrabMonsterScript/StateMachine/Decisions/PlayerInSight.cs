using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CrabSM/Decisions/PlayerInSight", fileName = "IsInSight")]
public class PlayerInSight : CrabDecision
{
    public override bool Decide(CrabBaseStateMachine state)
    {
        return Random.Range(0, 2) == 1;
    }
}
