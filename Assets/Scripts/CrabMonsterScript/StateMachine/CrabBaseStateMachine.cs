using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
[RequireComponent(typeof(NavMeshAgent), typeof(CrabAnimation), typeof(CrabSight))]
[RequireComponent(typeof(CrabAudioManager), typeof(CrabParticles))]
public sealed class CrabBaseStateMachine : MonoBehaviour
{
    [SerializeField] private CrabBaseState _State;
    [SerializeField] private CrabMovementData _MovementData;
    public CrabMovementData m_MovementData { get { return _MovementData; } }
    [HideInInspector] public CrabSight m_Vision { private set; get; }
    [HideInInspector] public NavMeshAgent m_NavMesh { private set; get; }
    [HideInInspector] public CrabAnimation m_Animation { private set; get; }
    [HideInInspector] public CrabAudioManager m_AudioManager { private set; get; }
    [HideInInspector] public CrabParticles m_CrabParticule { private set; get; }

    private float _TimeCounter = 0f;
    public float TimeSinceInState { get { return _TimeCounter; } }

    [SerializeField]
    private bool _DebugPath;

    private void Awake()
    {
        m_NavMesh = GetComponent<NavMeshAgent>();
        m_Animation = GetComponent<CrabAnimation>();
        m_Vision = GetComponent<CrabSight>();
        m_AudioManager = GetComponent<CrabAudioManager>();
        m_CrabParticule = GetComponent<CrabParticles>();
        SetMoveData(_MovementData);
    }
    public void SetMoveData(CrabMovementData newMovementsDatas)
    {
        _MovementData = newMovementsDatas;
        m_NavMesh.acceleration = _MovementData.Acceleration;
        m_NavMesh.angularSpeed = _MovementData.TurnSpeed;
        m_NavMesh.speed = _MovementData.MoveSpeed;
        m_NavMesh.stoppingDistance = _MovementData.DestinationRadius/2f;
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
        Debug.Log($"Entering " + _State.ToString() + " State");
        _State.OnEnterState(this);

    }

    public void Update()
    {
        _TimeCounter += Time.deltaTime;
        _State.PlayState(this);
        // Debug.Log(_State.ToString());
    }

    private void OnDrawGizmos()
    {
        if(_DebugPath)
        {
            if (m_NavMesh == null) return;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + m_NavMesh.velocity);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + m_NavMesh.desiredVelocity);
            Gizmos.color = Color.black;
            NavMeshPath CrabPath = m_NavMesh.path;
            Vector3 PreviousCorner = transform.position;
            foreach(Vector3 Corner in CrabPath.corners) {
                Gizmos.DrawLine(PreviousCorner, Corner);
                Gizmos.DrawSphere(Corner, 0.1f);
                PreviousCorner = Corner;
            }
        }
    }

}
