using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private InputActionProperty grabButton;
    private Collider[] colliders;
    [SerializeField] private float _ColliderDeactivationDelay = 0.25f;
    private void Awake()
    {
        colliders = GetComponentsInChildren<Collider>();
        Debug.Log(colliders.Length);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator SetComponentEnable(bool enable)
    {
        yield return new WaitForSeconds(_ColliderDeactivationDelay);
        foreach (Collider collider in colliders)
        {
            collider.enabled = enable;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(grabButton.action.WasPressedThisFrame())
        {
            StopCoroutine("SetComponentEnable");
            StartCoroutine(SetComponentEnable(false));
        }
        else if(grabButton.action.WasReleasedThisFrame())
        {
            StopCoroutine("SetComponentEnable");
            StartCoroutine(SetComponentEnable(true));
        }
    }
}
