using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rikayon : MonoBehaviour {

    public Animator animator;
    private FireBulletOnActivate fireBulletOnActivate;
    private life m_life;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Attack_1");
        }

	}
    private void OnTriggerEnter(Collider other)
    {        
         Debug.Log("oui");         
         	
    }
}
