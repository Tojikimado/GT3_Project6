using UnityEngine;
using UnityEngine.Accessibility;

[CreateAssetMenu(menuName = "Data/Crab/Sight")]
public class CrabSightData : ScriptableObject
{
    [Header("Tags")]
    [SerializeField]
    private string _PlayerTag = "GameController";
    public string PlayerTag { get { return _PlayerTag; } }
    [SerializeField]
    private string _EatableTag = "Eatable";
    public string EatableTag { get { return _EatableTag; } }
    [SerializeField]
    private string _PatrolPointTag = "PatrolPoints";
    public string PatrolPointTag { get { return _PatrolPointTag; } }

    [Header("Vision")]
    [SerializeField]
    [Range(2f, 60f)]
    private float _VisionRange = 15f;
    public float VisionRange { get { return _VisionRange; } }

    [Header("Reaction time")]
    [SerializeField]
    [Range(0.01f, 10f)]
    private float _ReactionTime = 0.4f;
    public float ReactionTime { get { return _ReactionTime; } }


}

