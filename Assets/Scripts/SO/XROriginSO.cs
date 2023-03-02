using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

[CreateAssetMenu(fileName = "XR Origin", menuName = "XR Origin")]
public class XROriginSO : ScriptableObject
{
    [SerializeField] private bool continuousTurn;
    public bool ContinuousTurn { get => continuousTurn; set => continuousTurn = value; }
}
