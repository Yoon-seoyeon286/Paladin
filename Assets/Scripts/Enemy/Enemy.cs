using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public int hp ;

    private Animator animator;
    int deadCount;
    int totalDamage;
    public EnemyData enemyData;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        deadCount = 0;
       hp= enemyData.hp;
       
    }


    public void Damage(int damage)
    {
        totalDamage += damage;

        if (hp <= 0) return;

        if (hp > 0)
        {
            hp -= totalDamage;

            if (hp <= 0)
            {
                hp = 0;
                Task.FromResult(Die());
            }
        }

    }


    private async Task Die()
    {
        animator.SetTrigger("Dead");
        deadCount++;

        UIManager.instance.LevelText(deadCount);
        Coin.instance.GetCoin(10);
    
        await Task.Delay(1500);
        Destroy(gameObject);
        
    }
}
