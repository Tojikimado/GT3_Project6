using System.Collections.Generic;
using UnityEngine;


public class CrabBaseState : ScriptableObject
{
    [SerializeField]
    private CrabTransitions[] _transitions;

    public virtual void OnEnterState(CrabBaseStateMachine Machine) {}
    public virtual void PlayState(CrabBaseStateMachine Machine) {}
    public virtual void OnExitState(CrabBaseStateMachine Machine) {}
}
