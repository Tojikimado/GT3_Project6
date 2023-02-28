using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Patrol", fileName = "Simple Patrol")]
public class ClosestPointPatrol : SimplePatrol
{
    protected override void GetPatrolPoint(CrabBaseStateMachine Machine)
    {
        if (Machine.m_Vision.HasPatrolPoints)
        {
            float ShortestDistance = float.PositiveInfinity;
            Transform TempTargetTransform = null;
            foreach (var point in Machine.m_Vision.PatrolPoints)
            {
                float SqrTestedDistance = (point.position - Machine.transform.position).sqrMagnitude;
                if (ShortestDistance < SqrTestedDistance)
                {
                    if (SqrTestedDistance > Machine.m_MovementData.DestinationRadius* Machine.m_MovementData.DestinationRadius)
                    {
                        TempTargetTransform = point;
                        ShortestDistance = SqrTestedDistance;
                    }
                }
            }
            if (TempTargetTransform != null)
                _PatrolPoint = TempTargetTransform;
        }
    }

    protected override void OnDestinationArrived(CrabBaseStateMachine Machine)
    {
        Machine.m_Vision.PatrolPoints.Remove(_PatrolPoint);
        base.OnDestinationArrived(Machine);
    }
}
