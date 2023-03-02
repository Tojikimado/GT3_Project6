using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/EmptyState", fileName = "EmptyState")]
public class CrabBaseState : ScriptableObject
{
    [SerializeField]
    private CrabTransitions[] _transitions;

    [Tooltip("The sight data that will be during and after this state")]
    [SerializeField]
    protected CrabSightData _sightData;

    [Tooltip("The movements data that will be used during and after this state")]
    [SerializeField]
    protected CrabMovementData _movementData;

    public virtual void OnEnterState(CrabBaseStateMachine Machine) {
        Machine.SetMoveData(_movementData);
        Machine.m_Vision.SetSightDatas(_sightData);
    }
    public virtual void PlayState(CrabBaseStateMachine Machine) {
        foreach (var transition in _transitions)
        {
            if (transition != null) 
                transition.Execute(Machine);
        }
    }
    public virtual void OnExitState(CrabBaseStateMachine Machine) {}
}
