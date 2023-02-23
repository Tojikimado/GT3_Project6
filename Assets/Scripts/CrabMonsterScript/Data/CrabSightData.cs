using UnityEngine;
using UnityEngine.Accessibility;

[CreateAssetMenu(menuName = "Data/Crab/Sight")]
public class CrabSightData : ScriptableObject
{
    [SerializeField]
    private string _PlayerTag = "GameController";
    public string PlayerTag { get { return _PlayerTag; } }


    [Header("Vision")]
    [SerializeField]
    [Range(2f, 25f)]
    private float _VisionRange = 15f;
    public float VisionRange { get { return _VisionRange; } }

   

    [Header("Reaction time")]
    [SerializeField]
    [Range(0.01f, 10f)]
    private float _ReactionTime = 0.4f;
    public float ReactionTime { get { return _ReactionTime; } }


}

