using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ActionAttack : FSMAction
{
    [Header("Config")]
    [SerializeField] private float damage;
    [SerializeField] private float timeBetweenAttacks;

    private EnemyBrain enemyBrain;
    private float timer;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }

    public override void Act()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (enemyBrain.Player == null) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            IDamageable player = enemyBrain.Player.GetComponent<IDamageable>();
            player.TakeDamage(damage);
            timer = timeBetweenAttacks;
        }
    }
}