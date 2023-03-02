using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Password", menuName = "Password Enigma")]
public class passwordmanager : ScriptableObject
{
    private string solution;
    [SerializeField]
    private string RightSolution = "1234";
    [SerializeField] private Door door;
     public void test(string u)
    {
        solution += u;
           if (solution.Contains(RightSolution))
            {
                Debug.Log("WIN");
                door.OpenCloseDoor();
            }
              Debug.Log(solution);
    }
    public void Reset() {
        solution = "";
    }
}
