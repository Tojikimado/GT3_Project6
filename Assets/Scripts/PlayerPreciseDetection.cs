using UnityEngine;

using UnityEngine.XR;

using UnityEngine.XR.Interaction.Toolkit;

public class PlayerPreciseDetection : MonoBehaviour
{
    [SerializeField]
    private InputDevice LeftControllerDevice;
    [SerializeField]
    private InputDevice RightControllerDevice;

    private Vector3 LeftControllerVelocity;
    private Vector3 RightControllerVelocity;

    [SerializeField]
    private PlayerMovementDetection _PlayerMovementDetection;

    void Start()
    {
        LeftControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        RightControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
    void Update()
    {
        UpdateInput();
        Debug.Log($"Left vel : {LeftControllerVelocity.magnitude}, Right Vel : {RightControllerVelocity.magnitude}, SpeedTest : {_PlayerMovementDetection.SpeedDetection}");
        if (LeftControllerVelocity.magnitude > _PlayerMovementDetection.SpeedDetection)
        {
            _PlayerMovementDetection.SetIsMoving(true);

        } else if (RightControllerVelocity.magnitude > _PlayerMovementDetection.SpeedDetection)
        {
            _PlayerMovementDetection.SetIsMoving(true);
        } else
        {
            _PlayerMovementDetection.SetIsMoving(false);
        }
    }
    void UpdateInput()
    {
        LeftControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out LeftControllerVelocity);
        RightControllerDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out RightControllerVelocity);
    }

}
