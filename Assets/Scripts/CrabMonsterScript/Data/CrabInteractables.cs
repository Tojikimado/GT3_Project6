using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabInteractables : MonoBehaviour
{
    [SerializeField]
    private CrabInteractablesData _InteractablesData;

    [SerializeField]
    private CrabInteractablesEnum _InteractableType;
    private void OnDrawGizmos()
    {
        if (_InteractableType == CrabInteractablesEnum.PatrolPoints)
            Gizmos.color = _InteractablesData.PatrolPointsDebugColor;
        else if (_InteractableType == CrabInteractablesEnum.Eatables)
            Gizmos.color = _InteractablesData.EatablesDebugColor;
        Gizmos.DrawSphere(transform.position, _InteractablesData.Radius);
    }
}
[System.Serializable]
public enum CrabInteractablesEnum
{
    PatrolPoints,
    Eatables
}
