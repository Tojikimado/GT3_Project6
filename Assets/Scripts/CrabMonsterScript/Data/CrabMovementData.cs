using UnityEngine;

[CreateAssetMenu(menuName="Data/Crab/Movement")]
public class CrabMovementData : ScriptableObject
{
    [Header("Move Speed")]
    [SerializeField]
    [Range(0f, 25f)]
    private float _MoveSpeed = 5f;
    public float MoveSpeed { get { return _MoveSpeed; } }

    [Header("Rotation Speed")]
    [SerializeField]
    [Range(0f, 180f)]
    private float _TurnSpeed = 10f;
    public float TurnSpeed { get { return _TurnSpeed; } }

    [Header("Acceleration")]
    [SerializeField]
    [Range(0f, 25f)]
    private float _Acceleration = 0.5f;
    public float Acceleration { get { return _Acceleration; } }

    [Header("Movement Precision")]
    [SerializeField]
    [Range(0.01f, 2f)]
    private float _DestinationRadius = 0.5f;
    public float DestinationRadius { get { return _DestinationRadius; } }


}
