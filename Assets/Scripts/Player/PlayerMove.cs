using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float AttackRange { get; private set; }
    Animator animator;
    IDamageable currentTarget;


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
        CleanDeadEnemies();
        ChooseTarget();
        if (currentTarget != null)
        {
            animator.SetBool("Attack", true);
        }

        else
        {
            animator.SetBool("Attack", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
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
        if (currentTarget != null)
        {
            currentTarget.Damage(damage);
        }
    }

    void CleanDeadEnemies()
    {
        for (int i = enemiesInRange.Count - 1; i > 0; i--)
        {
            if (enemiesInRange[i] == null)
            {
                enemiesInRange.RemoveAt(i);
            }
        }
    }

    void ChooseTarget()
    {
        if ( !enemiesInRange.Contains(currentTarget))
        {
            if (enemiesInRange.Count > 0)
            {
                currentTarget = enemiesInRange[0];
            }
            else
            {
                currentTarget = null;
            }
        }
    }


}
