using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _Animator;

    private string _CurrentState;
    // Start is called before the first frame update
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
        _Animator.SetTrigger(Animation);
        _CurrentState = Animation;
    }
}
