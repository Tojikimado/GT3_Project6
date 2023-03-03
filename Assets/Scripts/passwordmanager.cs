using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    private string solution;
    [SerializeField] private string RightSolution = "1234";
    [SerializeField] private Door door;

    private void Start()
    {
        ResetSolution();
    }

    public void AddToSolution(string u)
     {
        if (solution.Length < 4)
            solution += u;
        else
        {
            ResetSolution();
            solution += u;
        }

        if (solution.Length == 4 && solution.Contains(RightSolution) && !door.IsOpen)
            door.OpenDoor();


        Debug.Log(solution.Length);
        Debug.Log(solution);
        Debug.Log(RightSolution);
        Debug.Log(solution.Contains(RightSolution));
     }

    public void ResetSolution()
    {
        solution = "";
    }
}
