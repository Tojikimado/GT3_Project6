using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Door : MonoBehaviour {

    

    [SerializeField] private float _OpenCloseDelay = 2f;

    private int trDoorOpen = Animator.StringToHash("DoorOpen");
    private int trDoorClose = Animator.StringToHash("DoorClose");
    private Animator animator;
    private AudioSource audioSource;
    private float _OpenCloseTimer = float.PositiveInfinity;
    private bool _CanOpen { get { return _OpenCloseTimer>=_OpenCloseDelay; } }

    private bool _IsOpen = false;

	void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}


	void OnTriggerEnter(Collider c) {
        OpenTriggerDoor(c);
    }

	void OnTriggerExit(Collider c) {
        CloseTriggerDoor(c);
	}

    public void OpenTriggerDoor(Collider c) {
        if (c.tag.Equals("GameController")) {
            audioSource.Play();
            animator.SetTrigger(trDoorOpen);
        }
    }
    public void CloseTriggerDoor(Collider c) {
        if (c.tag.Equals("GameController")) {
            audioSource.Play();
            animator.SetTrigger(trDoorClose);
        }
    }
    private void Update()
    {
        _OpenCloseTimer += Time.deltaTime;
    }

    public void OpenDoor()
    {
        if (!_CanOpen) return;
        _OpenCloseTimer = 0f;
        audioSource.Play();
        animator.SetTrigger(trDoorOpen);
        _IsOpen = true;
    }

    public void CloseDoor()
    {
        if (!_CanOpen) return;
        _OpenCloseTimer = 0f;
        audioSource.Play();
        animator.SetTrigger(trDoorClose);
        _IsOpen = false;
    }

    public void OpenCloseDoor()
    {
        if (!_CanOpen) return;
        _OpenCloseTimer = 0f;
        audioSource.Play();
        if(!_IsOpen)
        {
            animator.SetTrigger(trDoorOpen);
            _IsOpen = true;
        }
        else if(_IsOpen)
        {
            animator.SetTrigger(trDoorClose);
            _IsOpen = false;
        }
    }
}
