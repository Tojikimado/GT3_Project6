using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rikayon : MonoBehaviour {

    private GameObject CrabMonster;
    public Animator animator;
    private FireBulletOnActivate fireBulletOnActivate;
   
	// Use this for initialization
	void Start () {
		CrabMonster = GameObject.Find("CrabMonster1");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Attack_1");
        }
	}
  
}
