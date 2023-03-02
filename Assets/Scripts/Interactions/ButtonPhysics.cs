using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPhysics : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

   
[SerializeField]
private passwordmanager passwordmanager;
 
    private bool _isPressed = false;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent OnPressed, OnReleased;
    // Start is called before the first frame update
    void Start()
    {
       

        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        passwordmanager.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if(_isPressed && GetValue()  - threshold <= 0)
            Released();
            
          
          
    }

    private float GetValue()
    {
        float value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        OnPressed.Invoke();
    }

    private void Released()
    {
        _isPressed = false;
        OnReleased.Invoke();
    }

   
}
