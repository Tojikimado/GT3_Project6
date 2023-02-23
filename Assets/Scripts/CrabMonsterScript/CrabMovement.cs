using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CrabMovement : MonoBehaviour
{
    [SerializeField]
    public CrabMovementData CurrentCrabMovement;
}
