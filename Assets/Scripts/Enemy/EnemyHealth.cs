using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private float health;

    public float CurrentHealth { get; private set; }
    private Animator animator;
    private EnemyBrain enemyBrain;
    private EnemySelector enemySelector;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyBrain = GetComponent<EnemyBrain>();
        enemySelector = GetComponent<EnemySelector>();
    }


    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0f)
        {
            animator.SetTrigger("Dead");
            enemyBrain.enabled = false;
            enemySelector.NoSelectionCallback();
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        else 
        {
            DamageManager.Instance.ShowDamageText(amount, transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = health;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
