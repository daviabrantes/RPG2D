using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private void Update()
    {

    }

    public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if (stats.Health < 0f)
        {

        }
    }

    private void PlayerDead()
    {

    }
}
