using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/GoEating", fileName = "Go Eat")]
public class GoEating : SimplePatrol
{
    protected override void GetPatrolPoint(CrabBaseStateMachine Machine)
    {
        if (Machine.m_Vision.Eatables.Count>=1)
        {
            int Index = Random.Range(0, Machine.m_Vision.Eatables.Count);
            int counter = 0;
            foreach (var Eatables in Machine.m_Vision.Eatables)
            {
                if (Index == counter)
                {
                    // Debug.Log("Setting Eatables");
                    _PatrolPoint = Eatables;
                    break;
                }
                counter++;
            }
        }
        OnRefreshPath(Machine);
    }

    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        GetPatrolPoint(Machine);
    }
}
