using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    public float _life;
    private GameObject CrabMonster;
    // Start is called before the first frame update
    void Start()
    {
        CrabMonster = GameObject.Find("CrabMonster1");

    }
    // Update is called once per frame
    void Update()
    {
       if(_life == 0)
        {
            Destroy(CrabMonster, 2f);
        }
    }
}
