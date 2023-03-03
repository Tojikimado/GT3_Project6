using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Crab"))
            other.transform.GetComponent<IDamageable>()?.TakeDamage(30f);
        Destroy(this);
    }   
}
