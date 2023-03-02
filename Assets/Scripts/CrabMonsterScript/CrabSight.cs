using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public sealed class CrabSight : MonoBehaviour
{
    [SerializeField]
    private CrabSightData _SightDatas;
    private SphereCollider _SphereCollider;

    [Tooltip("The point where it will look at the player")]
    [SerializeField]
    private Transform _SightOffset;

    [SerializeField]
    private LayerMask _NonCrabLayer;

    private bool _PlayerIsInZone = false;
    public bool PlayerIsInZone { get { return _PlayerIsInZone; } }

    private bool _PlayerIsInSight = false;
    public bool PlayerIsInSight { get { return _PlayerIsInSight; } }

    public bool CanReact { get { return _ReactionTimeCounter > _SightDatas.ReactionTime; } }
    private Transform _PlayerTransform = null;
    public Transform PlayerTransform { get { return _PlayerTransform; } }

    private HashSet<Transform> _Eatables = new HashSet<Transform>();
    public HashSet<Transform> Eatables { get { return _Eatables; } }

    private HashSet<Transform> _PatrolPoints = new HashSet<Transform>();
    public HashSet<Transform> PatrolPoints { get { return _PatrolPoints; } }

    private float _ReactionTimeCounter = 0f;
    [SerializeField]
    private float _AttackRange = 2.75f;
    public float AttackRange { get { return _AttackRange; } }

    public bool CanEat { get { return _Eatables.Count > 0; } }
    public bool HasPatrolPoints { get { return _PatrolPoints.Count > 0; } }

    [SerializeField]
    private PlayerMovementDetection _PlayerMovements;
    public PlayerMovementDetection PlayerMovements { get { return _PlayerMovements; } }

    #region Debug
    private bool _Debug;
    #endregion

    private void Awake()
    {
        _SphereCollider = GetComponent<SphereCollider>();
        _SphereCollider.isTrigger=true;
        _SphereCollider.radius = _SightDatas.VisionRange;
    }

    public void SetSightDatas(CrabSightData newSight)
    {
        _SightDatas = newSight;
        _SphereCollider.radius = _SightDatas.VisionRange;
    }

    private void Start()
    {
        var Pgo = GameObject.FindGameObjectWithTag(_SightDatas.PlayerTag);
        _PlayerTransform = (Pgo != null) ? Pgo.transform : null;
    }
    private bool IsPlayerInDirectSight()
    {
        if (!_PlayerTransform) return false;
        RaycastHit Hit;
        if (Physics.Raycast(_SightOffset.position, 
            (_PlayerTransform.position - _SightOffset.position).normalized, 
            out Hit, 
            (_SightOffset.position - _PlayerTransform.position).sqrMagnitude, 
            _NonCrabLayer) && Hit.transform.CompareTag(_SightDatas.PlayerTag))
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(_SightDatas.PlayerTag)) {
            _PlayerIsInZone = true;
            _PlayerTransform = other.transform;
        } else if (other.transform.CompareTag(_SightDatas.EatableTag)) {
            _Eatables.Add(other.transform);
        } else if (other.transform.CompareTag(_SightDatas.PatrolPointTag)) {
            _PatrolPoints.Add(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(_PlayerTransform);
        
        //if (other.transform.CompareTag(_SightDatas.PlayerTag))
        //{
            
        //}
    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(_SightDatas.PlayerTag))
        {
            _PlayerIsInZone = false;
        }
        //else if (other.transform.CompareTag(_SightDatas.EatableTag))
        //{
        //    _Eatables.Remove(other.transform);
        //}
        //else if (other.transform.CompareTag(_SightDatas.PatrolPointTag))
        //{
        //    _Eatables.Remove(other.transform);
        //}
    }
    private void OnDrawGizmos()
    {
        if (!_Debug) return;
        if (_PlayerTransform == null) return;
        // Debug.Log("Tracing");
        RaycastHit Hit;
        Gizmos.color = Color.red;
        // Debug.Log(Physics.Raycast(_SightOffset.position, (_PlayerTransform.position - _SightOffset.position).normalized, out Hit, (_SightOffset.position - _PlayerTransform.position).sqrMagnitude, _NonCrabLayer));
        if (Physics.Raycast(_SightOffset.position, (_PlayerTransform.position - _SightOffset.position).normalized, out Hit, (_SightOffset.position - _PlayerTransform.position).sqrMagnitude, _NonCrabLayer))
        {
            // Debug.Log("Hit");
            if (Hit.transform.CompareTag(_SightDatas.PlayerTag))
                Gizmos.color = Color.green;
            Gizmos.DrawLine(_SightOffset.position, Hit.point);
        }
        else
        {
            Gizmos.DrawLine(_SightOffset.position, _SightOffset.position+(_PlayerTransform.position - _SightOffset.position)); // *(_SightOffset.position - _PlayerTransform.position).sqrMagnitude
        }
    }
    private void Update()
    {
        _PlayerIsInSight = IsPlayerInDirectSight();
        if (_PlayerIsInSight)
        {
            _ReactionTimeCounter += Time.fixedDeltaTime;
        }else
        {
            _ReactionTimeCounter = 0;
        }
    }
}
