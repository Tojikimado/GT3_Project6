using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(menuName = "Data/Player/MovementDetection", fileName = "PMovementDetection")]
public class PlayerMovementDetection : ScriptableObject
{
    [SerializeField]
    [Range(0f, 180f)]
    private float _angleDetection = 15f;
    public float AngleDetection { get { return _angleDetection; } }

    [SerializeField]
    [Range(0f, 10f)]
    private float _speedDetection = 0.15f;
    public float SpeedDetection {get {return _speedDetection; }}
    private bool _isMoving = false;
    public bool IsMoving { get { return _isMoving;} }

    private float _timeSinceMoved;
    public float TimeSinceMoved { get { return Time.time - _timeSinceMoved; }}

    public void SetIsMoving(bool isMoving)
    {
        if (!_isMoving && isMoving)
        {
            _timeSinceMoved = Time.time;
        }
        _isMoving = isMoving;
        
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerMovementDetection))]
[CanEditMultipleObjects]
public class PlayerMovementDetectionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlayerMovementDetection V = (PlayerMovementDetection)target;
        if (GUILayout.Button((V.IsMoving)? "Stop Moving" : "Start Moving")) {
            V.SetIsMoving(!V.IsMoving);
        }
    }
}
#endif
