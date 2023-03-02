using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;

    private InputAction _leftThumbstick;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var leftActivate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        leftActivate.Enable();
        leftActivate.performed += OnTeleportActivate;

        var leftCancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        leftCancel.Enable();
        leftCancel.performed += OnTeleportCancel;

        _leftThumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        _leftThumbstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
            return;

        if(_leftThumbstick.triggered)
            return;

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point
        };

        provider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        _isActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }
}
