using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
[RequireComponent(typeof(CrabAnimation), typeof(CrabSight), typeof(CrabParticles))]
[RequireComponent(typeof(CrabAudioManager), typeof(NavMeshAgent), typeof(Rigidbody))]
public sealed class CrabBaseStateMachine : MonoBehaviour, IDamageable
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



    #region Life Variables
    [SerializeField]
    private float _CrabDamage;
    public float CrabDamage { get { return _CrabDamage; } }
    [SerializeField]
    private float _MaxLife = 100f;
    private float _CurrentLife;
    [SerializeField]
    private CrabBaseState _DeathState;
    [SerializeField]
    private CrabBaseState _TakeDamageState;
    [SerializeField]
    private float _TakeDamageCooldown = 4;
    private float _TakeDamageCooldownCounter;
    #endregion
    #region Debug
    [SerializeField]
    private bool _DebugPath;
    [SerializeField]
    private bool _DebugState;
    #endregion
    private void Awake()
    {
        m_NavMesh = GetComponent<NavMeshAgent>();
        m_Animation = GetComponent<CrabAnimation>();
        m_Vision = GetComponent<CrabSight>();
        m_AudioManager = GetComponent<CrabAudioManager>();
        m_CrabParticule = GetComponent<CrabParticles>();
        SetMoveData(_MovementData);
        _CurrentLife = _MaxLife;
        _TakeDamageCooldownCounter = _TakeDamageCooldown;
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
        if(_DebugState)
            Debug.Log($"Entering " + _State.GetType().Name + " State");
        _State.OnEnterState(this);

    }

    public void Update()
    {
        
        _TakeDamageCooldownCounter += Time.deltaTime;
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
    #region Life-related Functions
    public void TakeDamage(float DamageAmount)
    {
        _CurrentLife -= DamageAmount;
        _CurrentLife = Mathf.Clamp(_CurrentLife, 0f, _MaxLife);
        if (_CurrentLife == 0)
        {
            ChangeState(_DeathState);
            enabled = false;
            return;
        }
        if(_TakeDamageCooldownCounter>_TakeDamageCooldown)
        {
            ChangeState(_TakeDamageState);
            _TakeDamageCooldownCounter = 0;
        }
        
    }
    public void Heal(float HealAmount)
    {
        _CurrentLife += HealAmount;
        _CurrentLife = Mathf.Clamp(_CurrentLife, 0f, _MaxLife);
    }

    #endregion
}
