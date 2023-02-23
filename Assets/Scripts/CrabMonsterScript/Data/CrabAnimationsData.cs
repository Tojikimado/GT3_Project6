using UnityEngine;

[CreateAssetMenu(menuName="Data/Crab/Animations")]
public class CrabAnimationsData : ScriptableObject
{
    [Header("Idle Animations")]
    [SerializeField]
    private string _Idle_Rest = "Rest_1";
    public string Idle_Rest { get { return _Idle_Rest; } }
    [SerializeField]
    private string _Idle_Fight = "Fight_Idle_1";
    public string Idle_Fight { get { return _Idle_Fight;} }

    [Header("Walking Animations")]
    [SerializeField]
    private string _Walk_Fast = "Walk_Cycle_1";
    public string Walk_Fast { get { return _Walk_Fast; } }
    [SerializeField]
    private string _Walk_Slow = "Walk_Cycle_2";
    public string Walk_Slow { get { return _Walk_Slow;} }
    [SerializeField]
    private string _Walk_Sneak = "Sneak_Cycle_1";
    public string Walk_Sneak { get { return _Walk_Sneak; } }
    
    [Header("Behaviour Animations")]
    [SerializeField]
    private string _Eat = "Eat_Cycle_1";
    public string Eat { get { return _Eat;} }
    [SerializeField]
    private string _Sleep = "Sleep";
    public string Sleep { get { return _Sleep;} }

    [Header("Emotes")]
    [SerializeField]
    private string _Intimidate_CloseUp = "Intimidate_1";
    public string Intimidate_CloseUp { get { return _Intimidate_CloseUp; } }
    [SerializeField]
    private string _Intimidate_Taunt = "Intimidate_2";
    public string Intimidate_Taunt { get { return _Intimidate_Taunt;} }
    [SerializeField]
    private string _Intimidate_Unbend = "Intimidate_3";
    public string Intimidate_Unbend { get { return _Intimidate_Unbend;} }

    [Header("Attacks")]
    [SerializeField]
    private string _Attack_LongArms = "Attack_1";
    public string Attack_LongArms { get { return _Attack_LongArms; } }
    [SerializeField]
    private string _Attack_LeftArm = "Attack_2";
    public string Attack_LeftArm { get { return _Attack_LeftArm; } }
    [SerializeField]
    private string _Attack_RightArm = "Attack_3";
    public string Attack_RightArm { get { return _Attack_RightArm; } }
    [SerializeField]
    private string _Attack_LargeArms = "Attack_4";
    public string Attack_LargeArms { get { return _Attack_LargeArms;} }
    [SerializeField]
    private string _Attack_HeadAttack = "Attack_5";
    public string Attack_HeadAttack { get { return _Attack_HeadAttack; } }

    [Header("Take Damage")]
    [SerializeField]
    private string _TakeDamage_Left = "Take_Damage_1";
    public string TakeDamage_Left { get { return _TakeDamage_Left; } }
    [SerializeField]
    private string _TakeDamage_Right = "Take_Damage_2";
    public string TakeDamage_Right { get { return _TakeDamage_Right; } }
    [SerializeField]
    private string _TakeDamage_Stun = "Take_Damage_3";
    public string TakeDamage_Stun { get { return _TakeDamage_Stun;} }
    [SerializeField]
    private string _Death = "Death";
    public string Death { get { return _Death; } }
    
    public static void PlayAnimation(Animator animator, string animationName)
    {
        animator.SetTrigger(animationName);
    }

    public string GetRandomTakeDamageAnim()
    {
        string[] list = { TakeDamage_Left, TakeDamage_Right, TakeDamage_Stun };
        return list[Random.Range(0, list.Length)];
    }
    public string GetRandomAttackAnim()
    {
        string[] list = { Attack_LongArms, Attack_LeftArm, Attack_RightArm, Attack_LargeArms, Attack_HeadAttack };
        return list[Random.Range(0, list.Length)];
    }
    public string GetRandomIntimidateAnim()
    {
        string[] list = { Intimidate_CloseUp, Intimidate_Taunt, Intimidate_Unbend };
        return list[Random.Range(0, list.Length)];
    }
}
