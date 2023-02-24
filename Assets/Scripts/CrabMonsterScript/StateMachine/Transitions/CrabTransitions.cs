using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName ="CrabSM/Transition")]
public sealed class CrabTransitions : ScriptableObject
{
    [SerializeField]
    private List<CrabDecision> _Decisions;
    [SerializeField]
    private bool _AllDecisionMustBeTrue = true;

    [SerializeField]
    private CrabBaseState TrueState;
    [SerializeField]
    private CrabBaseState FalseState;

    public void Execute(CrabBaseStateMachine CrabSM)
    {
        bool IsValidated = false;

        foreach(CrabDecision Decision in _Decisions)
        {
            if (Decision.Decide(CrabSM))
            {
                IsValidated = true;
                if (!_AllDecisionMustBeTrue)
                    break;
            } else
            {
                if (_AllDecisionMustBeTrue)
                {
                    IsValidated = false;
                    break;
                }
            }
        }
        if (IsValidated)
        {
            if (TrueState != null)
                CrabSM.ChangeState(TrueState);
        }
        else if (FalseState != null)
        {
            CrabSM.ChangeState(FalseState);
        }
    }
}
