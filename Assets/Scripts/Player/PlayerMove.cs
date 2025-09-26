using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float AttackRange { get; private set; }
    Animator animator;
    public SwordData equippedSword;


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



    public void Smash(int damage)
    {
        foreach (IDamageable enemy in enemiesInRange)
        {
            enemy.Damage(damage);
        }

        if (equippedSword != null)
        {
            int swordDamage = equippedSword.baseDamage;
            if (InventoryManager.instance.playerSwords.ContainsKey(equippedSword))
            {
                PlayerSwordStats stats = InventoryManager.instance.playerSwords[equippedSword];
                if (stats.level > 1 && stats.level % 2 == 0)
                {
                    swordDamage += 10;
                }
            }

            foreach (IDamageable enemy in enemiesInRange)
            {
                enemy.Damage(swordDamage);
                UIManager.instance.SetSwordPluseDamage(swordDamage);
            }
        }
    }

    public void EquipSword(SwordData swordData)
    {
        equippedSword = swordData;
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
