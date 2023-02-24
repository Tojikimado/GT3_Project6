using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
[RequireComponent(typeof(NavMeshAgent), typeof(CrabAnimation), typeof(CrabSight))]
public sealed class CrabBaseStateMachine : MonoBehaviour
{
    [SerializeField] private CrabBaseState _State;
    [SerializeField] private CrabMovementData _MovementData;
    [HideInInspector] public CrabSight m_Vision;
    [HideInInspector] public NavMeshAgent m_NavMesh;
    [HideInInspector] public CrabAnimation m_Animation;

    private float _TimeCounter = 0f;
    public float InStateTimeCounter { get { return _TimeCounter; } }

    private void Awake()
    {
        m_NavMesh = GetComponent<NavMeshAgent>();
        m_Animation = GetComponent<CrabAnimation>();
        m_Vision = GetComponent<CrabSight>();
        SetMoveData(_MovementData);
    }
    public void SetMoveData(CrabMovementData newMovementsDatas)
    {
        _MovementData = newMovementsDatas;
        m_NavMesh.acceleration = _MovementData.Acceleration;
        m_NavMesh.angularSpeed = _MovementData.TurnSpeed;
        m_NavMesh.speed = _MovementData.MoveSpeed;
    }

    private void Start()
    {
        _State.OnEnterState(this);
    }

    public void ChangeState(CrabBaseState newState)
    {
        if (newState == _State) return;
        _State.OnExitState(this);
        _TimeCounter = 0f;
        _State = newState;
        _State.OnEnterState(this);
    }

    public void Update()
    {
        _TimeCounter += Time.deltaTime;
        _State.PlayState(this);
    }
}
