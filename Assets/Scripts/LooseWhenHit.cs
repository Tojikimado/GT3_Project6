using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseWhenHit : MonoBehaviour, IDamageable
{
    public void TakeDamage(float Damage)
    {
        if (Damage > 70f)
            SceneManager.LoadSceneAsync("LooseScene", LoadSceneMode.Single);
    }

}
