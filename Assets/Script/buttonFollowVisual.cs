using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum Enigme
	{
		Button1,
		Button2,
		Button3,
		Button4
	}

public class buttonFollowVisual : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;
    public float resetSpeed = 5;

    private string SolutionCode;

    private bool freeze = false;

    private Vector3 initialLocalPos;
    private Vector3 offset;
    private Transform pokeAttachTransform;

    public XRBaseInteractable interctable;
    private bool isFollowing = false;

     private buttonFollowVisual bfv;
    private GameObject ButtonRouge;
    private GameObject ButtonBleu;
    private GameObject ButtonVert;
    private GameObject ButtonJaune; 
    // Start is called before the first frame update
    void Start()
    {

        //ButtonRouge = GameObject.Find("Button Rouge");
        ButtonBleu = GameObject.Find("Button Bleu");
        ButtonVert = GameObject.Find("Button Vert");
        ButtonJaune = GameObject.Find("Button Jaune");
        ButtonRouge = GameObject.FindWithTag("Button1");

        initialLocalPos = visualTarget.localPosition;

        interctable = GetComponent<XRBaseInteractable>();
        interctable.hoverEntered.AddListener(Follow);
        interctable.hoverExited.AddListener(Reset);
        interctable.selectEntered.AddListener(Freeze);
    }


    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {                       
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;
            freeze = false;

            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;
        }       
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            freeze = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (freeze)
            return;
       if(isFollowing)
       {
        Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
        Vector3 constrainecLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);

        visualTarget.position = visualTarget.TransformPoint(constrainecLocalTargetPosition);
       }
       else
       {
        visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
       }
        if (SolutionCode == "1234")
        {
            Debug.Log("WIN");
        }
    }
}
