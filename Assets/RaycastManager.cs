using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngineInternal;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] private XRRayInteractor rightRay;
    [SerializeField] private LineRenderer rightLine;

    // Start is called before the first frame update
    void Start()
    {
        rightLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        rightLine.enabled = false;
        if (rightRay.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if(hit.transform.gameObject.layer == 5)
            {
                Debug.Log("1");
                //rightLine.enabled = true;
            }
        }
    }
}
