using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "CrabSM/States/Patrol", fileName = "Simple Patrol")]
public class SimplePatrol : CrabBaseState
{
    [SerializeField] protected float _PathRefresh = 1f;
    protected float _RefreshTimeCounter = 0f;
    protected Transform _PatrolPoint;

    protected string _PatrolAnim;

    protected virtual void GetRandomPatrolPoint(CrabBaseStateMachine Machine)
    {
        if (Machine.m_Vision.HasPatrolPoints)
        {
            int Index = Random.Range(0, Machine.m_Vision.PatrolPoints.Count);
            int counter = 0;
            foreach (var point in Machine.m_Vision.PatrolPoints)
            {
                if (Index == counter)
                {
                    _PatrolPoint = point;
                    break;
                }
                counter++;
            }
        }
    }
    protected virtual void OnRefreshPath(CrabBaseStateMachine Machine)
    {
        Machine.m_NavMesh.destination = _PatrolPoint.position;
        _RefreshTimeCounter = 0f;
    }
    protected virtual void OnDestinationArrived(CrabBaseStateMachine Machine)
    {
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Idle_Rest);
        GetRandomPatrolPoint(Machine);
    }
    protected virtual void SetPatrolAnim(CrabBaseStateMachine Machine)
    {
        _PatrolAnim = Machine.m_Animation.AnimationsData.Walk_Slow;
    }

    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        SetPatrolAnim(Machine);
        GetRandomPatrolPoint(Machine);
    }
    

    public override void PlayState(CrabBaseStateMachine Machine)
    {
        _RefreshTimeCounter += Time.deltaTime;
        if (_PatrolPoint==null)
        {
            Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Idle_Rest);
            GetRandomPatrolPoint(Machine);
            return;
        }
        Machine.m_Animation.ChangeState(_PatrolAnim);
        if (_RefreshTimeCounter < _PathRefresh) return;
        float Distance = (Machine.transform.position - _PatrolPoint.position).sqrMagnitude;
        if (Distance > Machine.m_MovementData.DestinationRadius*Machine.m_MovementData.DestinationRadius)
        {
            if (Machine.m_NavMesh.pathStatus != NavMeshPathStatus.PathPartial)
            {
                OnRefreshPath(Machine);
            }
        } else
        {
            OnDestinationArrived(Machine);
        }
        base.PlayState(Machine);
    }


    public override void OnExitState(CrabBaseStateMachine Machine)
    {
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Idle_Rest);
        base.OnExitState(Machine);

    }
}
