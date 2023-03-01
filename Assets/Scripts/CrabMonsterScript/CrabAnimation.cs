using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

[RequireComponent(typeof(Animator))]
public class CrabAnimation : MonoBehaviour
{
    private Animator _Animator;

    [SerializeField]
    private CrabAnimationsData _AnimationData;
    public CrabAnimationsData AnimationsData { get { return _AnimationData; } }

    private string _CurrentState;


    private void Awake()
    {
        _Animator = GetComponent<Animator>();
    }

    public void ChangeState(string newState)
    {
        if (_CurrentState == newState) return;
        
        SetAnim(newState);
    }

    public void SetAnim(string Animation)
    {
        // Debug.Log("Setting Anim to " + Animation);
        _Animator.SetTrigger(Animation);
        _CurrentState = Animation;
    }
}
