using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CrabSM/States/Attack", fileName = "Simple Attack")]
public class Attack : CrabBaseState
{
    [SerializeField]
    private float _DamageDelay = 0.95f;
    private float _DelayTimeCounter = 0f;

    [SerializeField]
    private float _AttackRotationSpeed = 90f;
    public override void OnEnterState(CrabBaseStateMachine Machine)
    {
        base.OnEnterState(Machine);
        Machine.m_Animation.SetAnim(Machine.m_Animation.AnimationsData.GetRandomAttackAnim());
        Machine.m_NavMesh.destination = Machine.transform.position;
        _DelayTimeCounter = _DamageDelay;
        //if (Machine.m_Vision.PlayerTransform!=null)
        //    if ((Machine.transform.position - Machine.m_NavMesh.destination).sqrMagnitude <= Machine.m_Vision.AttackRange * Machine.m_Vision.AttackRange)
        //    {
        //        Machine.m_Vision.PlayerTransform.GetComponent<IDamageable>().TakeDamage(Machine.CrabDamage);
        //    }
    }
    public override void PlayState(CrabBaseStateMachine Machine)
    {
        _DelayTimeCounter -= Time.deltaTime;
        var TempForward = (Machine.m_Vision.PlayerTransform.position - Machine.transform.position).normalized;
        var Angle = Vector3.SignedAngle(new Vector3(TempForward.x, 0f, TempForward.z), Machine.transform.forward, Vector3.up)*-1;
        Machine.transform.forward = Quaternion.Euler(0, Mathf.Clamp(Angle, -_AttackRotationSpeed*Time.deltaTime, +_AttackRotationSpeed*Time.deltaTime), 0)*Machine.transform.forward;
        
        if (Machine.m_Vision.PlayerTransform != null && _DelayTimeCounter < 0)
            if ((Machine.transform.position - Machine.m_NavMesh.destination).sqrMagnitude <= Machine.m_Vision.AttackRange * Machine.m_Vision.AttackRange)
            {
                Machine.m_Vision.PlayerTransform.GetComponent<IDamageable>()?.TakeDamage(Machine.CrabDamage);
                _DelayTimeCounter = _DamageDelay;
            }
        base.PlayState(Machine);
    }
}
