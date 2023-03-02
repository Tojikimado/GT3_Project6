using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Seek For Player", fileName = "Seek for Player")]
public class Seekingfor : SimplePatrol
{
    [SerializeField]
    [Range(0f, 5f)]
    private float _TauntingTime = 1.0f;
    private float _TauntingTimeCounter = 0f;

    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Intimidate_Unbend);
        _PatrolPoint = Machine.m_Vision.PlayerTransform;
    }
    protected override void OnDestinationArrived(CrabBaseStateMachine Machine)
    {
        base.OnDestinationArrived(Machine);

        _TauntingTimeCounter = 0f;
        Machine.m_Animation.ChangeState(Machine.m_Animation.AnimationsData.Intimidate_Unbend);
    }

    protected override void GetPatrolPoint(CrabBaseStateMachine Machine)
    {
        if (Machine.m_Vision.PlayerTransform != null)
        {
            _PatrolPoint = Machine.m_Vision.PlayerTransform;
        }
    }

    protected override void SetPatrolAnim(CrabBaseStateMachine Machine)
    {
        _PatrolAnim = Machine.m_Animation.AnimationsData.Walk_Slow;
    }

    public override void PlayState(CrabBaseStateMachine Machine)
    {
        
        _TauntingTimeCounter += Time.deltaTime;
        if (_TauntingTimeCounter <= _TauntingTime)
        {
            // Machine.m_NavMesh.destination = Machine.transform.position;
            Machine.m_AudioManager.Play("Grunt");
        }
           
        base.PlayState(Machine);
    }


}