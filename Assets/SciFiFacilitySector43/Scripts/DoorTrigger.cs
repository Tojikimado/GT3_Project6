using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Door door;

    void Start()
    {
        door = GetComponentInParent<Door>();
    }

    void OnTriggerEnter(Collider c) {

        door.OpenTriggerDoor(c);

    }

    void OnTriggerExit(Collider c) {
        door.CloseTriggerDoor(c);
    }
}
