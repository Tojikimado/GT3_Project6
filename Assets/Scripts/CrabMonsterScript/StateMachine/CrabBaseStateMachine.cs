using UnityEngine;

public class CrabBaseStateMachine : MonoBehaviour
{
    [SerializeField] private CrabBaseState _initialState;

    [HideInInspector] public CrabMovement CrabMovement;
    [HideInInspector] public CrabAnimation CrabAnimation;


    private void Awake()
    {
        
    }

    public void ChangeState(CrabBaseState newState)
    {
        if (newState == _initialState) return;
        _initialState.OnExitState(this);
        _initialState = newState;
        _initialState.OnEnterState(this);
    }

    public void Update()
    {
        _initialState.PlayState(this);
    }
}
