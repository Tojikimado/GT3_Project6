using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/ClosestPatrol", fileName = "Closest Patrol")]
public class ClosestPointPatrol : SimplePatrol
{
    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        OnRefreshPath(Machine);
    }
    protected override void GetPatrolPoint(CrabBaseStateMachine Machine)
    {
        if (Machine.m_Vision.HasPatrolPoints)
        {
            float ShortestDistance = float.PositiveInfinity;
            Transform TempTargetTransform = null;
            foreach (var point in Machine.m_Vision.PatrolPoints)
            {
                if (_PatrolPoint == point)
                    continue;
                float SqrTestedDistance = (point.position - Machine.transform.position).sqrMagnitude;
                // Debug.Log($"Testing {point.name}, with distance of {SqrTestedDistance} and Shortest distance being {ShortestDistance}");
                if (ShortestDistance > SqrTestedDistance)
                {
                    TempTargetTransform = point;
                    ShortestDistance = SqrTestedDistance;
                    //Debug.Log(TempTargetTransform);
                }
            }
            if (TempTargetTransform != null)
                _PatrolPoint = TempTargetTransform;
        }
        OnRefreshPath(Machine);
    }

    protected override void OnDestinationArrived(CrabBaseStateMachine Machine)
    {
        Machine.m_Vision.PatrolPoints.Remove(_PatrolPoint);
        base.OnDestinationArrived(Machine);
    }
}
