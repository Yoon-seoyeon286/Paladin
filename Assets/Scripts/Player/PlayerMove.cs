using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float AttackRange { get; private set; }
    float totalDamage=0;
    Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        AttackRange = 5f;
    }

    private List<IDamageable> enemiesInRange = new List<IDamageable>();

    void Update()
    {

        if (enemiesInRange.Count > 0)
        {
            animator.SetBool("Attack", true);
        }

        else
        {
            animator.SetBool("Attack", false);
        }

        CleanDeadEnemies();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null && !enemiesInRange.Contains(damageable))
        {
            enemiesInRange.Add(damageable);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            enemiesInRange.Remove(damageable);
        }
    }



    public void Smash(float damage)
    {
        totalDamage += damage;

        foreach (IDamageable enemy in enemiesInRange)
        {
            enemy.Damage(totalDamage);
        }
    }

    void CleanDeadEnemies()
    {
        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            if (enemiesInRange[i] == null)
            {
                enemiesInRange.RemoveAt(i);
            }
        }
    }

}
