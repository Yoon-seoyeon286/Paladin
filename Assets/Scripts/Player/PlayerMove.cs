using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float AttackRange { get; private set; }
    Animator animator;
    public SwordData equippedSword;
    public AudioSource audioSource;
    public AudioClip smashAudioClip;


    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
        audioSource.PlayOneShot(smashAudioClip);
        foreach (IDamageable enemy in enemiesInRange)
        {
            enemy.Damage(damage);
        }

        if (equippedSword != null)
        {
            int swordDamage = equippedSword.baseDamage;
            int smashBonus = GetSmashBonus();
            int totalDamage = damage + swordDamage+smashBonus;

            int sendDamage = GetSmashBonus() + swordDamage;

            foreach (IDamageable enemy in enemiesInRange)
            {
                enemy.Damage(totalDamage);
               
            }
            UIManager.instance.SetSwordPluseDamage(sendDamage);

        }
    }

    int GetSmashBonus()
    {
        if (equippedSword == null) return 0;

        // 레벨이 짝수이면서 1 초과일 때만 +10 
        if (InventoryManager.instance.playerSwords.ContainsKey(equippedSword))
        {
            PlayerSwordStats stats = InventoryManager.instance.playerSwords[equippedSword];
            if (stats.level > 1 && stats.level % 2 == 0)
            {
                return 10;
            }
        }
        return 0;
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
