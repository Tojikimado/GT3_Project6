using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
[RequireComponent(typeof(NavMeshAgent), typeof(CrabAnimation))]
public sealed class CrabBaseStateMachine : MonoBehaviour
{
    [SerializeField] private CrabBaseState _State;

    [HideInInspector] public NavMeshAgent NavMesh;
    [HideInInspector] public CrabAnimation Animation;

    private float _TimeCounter = 0f;
    public float InStateTimeCounter { get { return _TimeCounter; } }

    private void Awake()
    {
        NavMesh = GetComponent<NavMeshAgent>();
        Animation = GetComponent<CrabAnimation>();
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
