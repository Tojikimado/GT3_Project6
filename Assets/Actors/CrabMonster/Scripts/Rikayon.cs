using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rikayon : MonoBehaviour {

    public Animator animator;
    public FireBulletOnActivate fireBulletOnActivate;
    public life m_life;
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
        if (fireBulletOnActivate.bullet)
        {
          	m_life._life -= 1;
        }
	
    }
}
