using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Password", menuName = "Password Enigma")]
public class passwordmanager : ScriptableObject
{
    private string solution;
    [SerializeField]
    private string RightSolution = "1234";
     public void test(string u)
    {
        solution += u;
           if (solution.Contains(RightSolution))
            {
                Debug.Log("WIN");
            }
              Debug.Log(solution);
    }
    public void Reset() {
        solution = "";
    }
}
