using UnityEngine;

[CreateAssetMenu(menuName = "Data/Crab/DebugInteractables")]
public class CrabInteractablesData : ScriptableObject
{
    [SerializeField]
    private Color _EatablesDebugColor = Color.green;
    public Color EatablesDebugColor { get { return _EatablesDebugColor; } }

    [SerializeField]
    private Color _PatrolPointsDebugColor = Color.blue;
    public Color PatrolPointsDebugColor { get { return _PatrolPointsDebugColor; } }

    [SerializeField]
    [Range(0.05f, 1f)]
    private float _Radius = 0.2f;
    public float Radius { get { return _Radius; } }

}