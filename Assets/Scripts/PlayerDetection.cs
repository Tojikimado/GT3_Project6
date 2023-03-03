using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField]
    private List<TransformTracker> _TrackedElements;
    [SerializeField]
    private PlayerMovementDetection _PlayerMovementDetection;
    private void Start()
    {
        foreach (TransformTracker tracker in _TrackedElements)
        {
            tracker.UpdateTrackingPos();
        }
    }

    private void Update()
    {
        bool HasMoved = false;
        foreach (TransformTracker tracker in _TrackedElements)
        {
            if (!HasMoved)
            {
                if (Quaternion.Angle(tracker.PreviousRotation, tracker.TrackedTransform.rotation) > _PlayerMovementDetection.AngleDetection * Time.deltaTime)
                {
                    HasMoved = true;
                }
                if ((tracker.PreviousPosition - tracker.TrackedTransform.position).sqrMagnitude > _PlayerMovementDetection.SpeedDetection * _PlayerMovementDetection.SpeedDetection * Time.deltaTime)
                {
                    HasMoved = true;
                }
                _PlayerMovementDetection.SetIsMoving(HasMoved);
            }
            tracker.UpdateTrackingPos();
        }
        // Debug.Log(_PlayerMovementDetection.IsMoving);
    }
}



[System.Serializable]
public struct TransformTracker
{
    [SerializeField]
    public Transform TrackedTransform;
    [HideInInspector]
    public Quaternion PreviousRotation;
    [HideInInspector]
    public Vector3 PreviousPosition;
    public void UpdateTrackingPos()
    {
        if (TrackedTransform != null)
        {
            TrackedTransform.position = PreviousPosition;
            TrackedTransform.rotation = PreviousRotation;
        }
    }
}