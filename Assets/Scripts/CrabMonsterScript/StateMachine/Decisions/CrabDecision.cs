using UnityEngine;

public abstract class CrabDecision : ScriptableObject
{
    public abstract bool Decide(CrabBaseStateMachine state);
}
