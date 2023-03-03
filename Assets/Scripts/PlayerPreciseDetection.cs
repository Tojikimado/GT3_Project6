using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

using UnityEngine.XR.Interaction.Toolkit;

public class PlayerPreciseDetection : MonoBehaviour
{
    private InputDevice LeftController;
    private InputDevice RightController;

    private float LeftControllerVelocity;
    private float RightControllerVelocity;

    [SerializeField]
    private PlayerMovementDetection _PlayerMovementDetection;

    void Start()
    {
        LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    private void InitializeInputDevices()
    {
        if (!LeftController.isValid)
            InitializeInput(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref LeftController);
        if (!RightController.isValid)
            InitializeInput(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref RightController); 
    }

    private void InitializeInput(InputDeviceCharacteristics inputChar, ref InputDevice inputDevice)
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(inputChar, devices);
        if (devices.Count > 0)
        {
            inputDevice = devices[0];
        }
    }
    void Update()
    {
        if (!RightController.isValid || !LeftController.isValid)
            InitializeInputDevices();
        Vector3 tempLeftVel;
        Vector3 tempRightVel;
        LeftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out tempLeftVel);
        RightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out tempRightVel);
        LeftControllerVelocity = tempLeftVel.magnitude;
        RightControllerVelocity = tempRightVel.magnitude;
        Debug.Log($"Left:{LeftControllerVelocity}, Right:{RightControllerVelocity}");
        if (LeftControllerVelocity > _PlayerMovementDetection.SpeedDetection)
        {
            _PlayerMovementDetection.SetIsMoving(true);
        } else if (RightControllerVelocity > _PlayerMovementDetection.SpeedDetection)
        {
            _PlayerMovementDetection.SetIsMoving(true);
        } else
        {
            _PlayerMovementDetection.SetIsMoving(false);
        }
    }

}
