using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractions : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject == key)
        {
            /*if(!door.IsOpen)
                door.OpenDoor();
            else if(door.IsOpen)
                door.CloseDoor();*/
            door.OpenCloseDoor();
        }
    }
}
