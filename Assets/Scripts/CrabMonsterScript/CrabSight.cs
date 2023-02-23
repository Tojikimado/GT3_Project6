using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSight : MonoBehaviour
{
    [SerializeField]
    private CrabSightData _CrabSightDatas;

    private bool _PlayerIsInSight;
    public bool PlayerIsInSight { get { return _PlayerIsInSight; } }

    private bool _CanEat;
    public bool CanEat;
}
