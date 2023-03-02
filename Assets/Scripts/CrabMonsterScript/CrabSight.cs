using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CrabSight : MonoBehaviour
{
    [SerializeField]
    private CrabSightData _SightDatas;
    private SphereCollider _SphereCollider;

    [Tooltip("The point where it will look at the player")]
    [SerializeField]
    private Transform _SightOffset;

    [SerializeField]
    private LayerMask _NonCrabLayer;

    private bool _PlayerIsInRange = false;
    public bool PlayerIsInRange { get { return _PlayerIsInRange; } }

    private bool _PlayerIsInSight = false;
    public bool PlayerIsInSight { get { return _PlayerIsInSight; } }

    private Transform _PlayerTransform = null;
    public Transform PlayerTransform { get { return _PlayerTransform; } }

    private HashSet<Transform> _Eatables = new HashSet<Transform>();
    public HashSet<Transform> Eatables { get { return _Eatables; } }

    private HashSet<Transform> _PatrolPoints = new HashSet<Transform>();
    public HashSet<Transform> PatrolPoints { get { return _PatrolPoints; } }

    private float _ReactionTimeCounter = 0f;

    public bool CanEat { get { return _Eatables.Count > 0; } }
    public bool HasPatrolPoints { get { return _PatrolPoints.Count > 0; } }

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
        if (Physics.Raycast(_SightOffset.position, _PlayerTransform.position - _SightOffset.position, out Hit, Vector3.Distance(_SightOffset.position, _PlayerTransform.position), _NonCrabLayer))
        {
            if (Hit.transform.CompareTag(_SightDatas.PlayerTag))
            {
                //Debug.Log("Is in direct sight");
                return true;
            }
            // Debug.Log($"Hit : {Hit.transform.name}");
            return false;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(_SightDatas.PlayerTag)) {
            _PlayerIsInRange = true;
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
        _PlayerIsInSight = IsPlayerInDirectSight();
        if (other.transform.CompareTag(_SightDatas.PlayerTag))
        {
            if (_PlayerIsInSight)
            {
                _ReactionTimeCounter += Time.fixedDeltaTime;
                Debug.Log(_ReactionTimeCounter);
            }
                
        }
    }

    public bool HasCrabSeenThePlayer()
    {
        return _ReactionTimeCounter > _SightDatas.ReactionTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(_SightDatas.PlayerTag))
        {
            _PlayerIsInRange = false;
            _ReactionTimeCounter = 0;
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
        if (_PlayerTransform == null) return;
        // Debug.Log("Tracing");
        RaycastHit Hit;
        if (Physics.Raycast(_SightOffset.position, (_PlayerTransform.position - _SightOffset.position).normalized, out Hit, (_SightOffset.position - _PlayerTransform.position).sqrMagnitude, _NonCrabLayer))
        {
            Debug.Log("Hit");
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_SightOffset.position, Hit.point);
        }
        else
        {
            Gizmos.DrawLine(_SightOffset.position, (_PlayerTransform.position - _SightOffset.position).normalized  *(_SightOffset.position-_PlayerTransform.position).sqrMagnitude);
        }
    }
    private void Update()
    {
        // Debug.Log(_PlayerIsInSight);
    }
}
