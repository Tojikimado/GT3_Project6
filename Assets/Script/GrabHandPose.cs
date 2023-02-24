using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabHandPose : MonoBehaviour
{
    /*
    public HandData rightHandPose;

    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandPosition;

    private Quaternion[] startingFingerRotation;
    private Quaternion[] finalFingerPosition;

    void Start()
    {
        XRGrabInteractable grabInteratable = GetComponent<XRGrabInteractable>();

        grabInteratable.selectEntered.AddListener(SetupPose);
        rightHandPose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            handData.animator.enabled = false;

            SetHandDataValues(handData, rightHandPose);
            SetHandData(handData , finalHandPosition, finalHandPosition, finalFingerPosition);
        }
    }
    public void SetHandDataValues(HandData h1, HandData h2)
    {
        startingHandPosition = h1.root.localPosition;
        finalHandPosition = h2.root.localPosition;

        startingHandPosition = h1.root.localPosition;
        finalHandPosition = h2.root.localPosition;

        startingFingerRotation = new Quaternion[h1.fingerBones.Length];
        finalFingerPosition = new Quaternion[h1.fingerBones.Length];

        for (int i = 0;i < h1.fingerBones.Length; i++)
        {
            startingFingerRotation[i] = h1.fingerBones[i].localPosition;
            finalFingerPosition[i]  = h2.fingerBones[i].localPosition;
        }
        
    }

    public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition =newPosition;
        h.root.localPosition =newPosition;

         for (int i = 0;i < newBonesRotation.Length; i++)
        {
           h.fingerBones[i].localPosition = newBonesRotation[i];
        } 
    }
    */
}
