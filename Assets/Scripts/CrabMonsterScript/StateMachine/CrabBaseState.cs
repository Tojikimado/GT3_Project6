using UnityEngine;


public class CrabBaseState : ScriptableObject
{
    public virtual void OnEnterState(CrabBaseStateMachine Machine) {}
    public virtual void PlayState(CrabBaseStateMachine Machine) {}
    public virtual void OnExitState(CrabBaseStateMachine Machine) {}
}
