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

    private bool _PlayerIsInRange = false;
    public bool PlayerIsInRange { get { return _PlayerIsInRange; } }



    private Transform _PlayerTransform;
    public Transform PlayerTransform { get { return _PlayerTransform; } }

    private HashSet<Transform> _Eatables = new HashSet<Transform>();
    private HashSet<Transform> _PatrolPoints = new HashSet<Transform>();

    
    public bool CanEat { get { return _Eatables.Count > 0; } }

    private void Awake()
    {
        _SphereCollider = GetComponent<SphereCollider>();
        _SphereCollider.isTrigger=true;
        _SphereCollider.radius = _SightDatas.VisionRange;
    }
    private void Start()
    {
        _PlayerTransform = GameObject.FindGameObjectWithTag(_SightDatas.PlayerTag).transform;
    }
    public bool IsPlayerInDirectSight()
    {
        if (!_PlayerTransform) return false;
        RaycastHit Hit;
        if (Physics.Raycast(_SightOffset.position, _PlayerTransform.position - _SightOffset.position, out Hit, Vector3.Distance(_SightOffset.position, _PlayerTransform.position)))
        {
            if (Hit.transform.CompareTag(_SightDatas.PlayerTag))
            {
                Debug.Log("Is in direct sight");
                return true;
            }
            Debug.Log($"Hit : {Hit.transform.name}");
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
            _Eatables.Add(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(_SightDatas.PlayerTag))
        {
            _PlayerIsInRange = false;
        }
        else if (other.transform.CompareTag(_SightDatas.EatableTag))
        {
            _Eatables.Remove(other.transform);
        }
        else if (other.transform.CompareTag(_SightDatas.PatrolPointTag))
        {
            _Eatables.Remove(other.transform);
        }
    }
    
}
