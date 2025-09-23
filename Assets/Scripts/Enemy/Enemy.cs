using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public float Hp = 100;

    private Animator animator;
    int deadCount;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        deadCount = 0;
       
    }


    public void Damage(float damage)
    {
        if (Hp <= 0) return;

        if (Hp > 0)
        {
            Hp -= damage;

            if (Hp <= 0)
            {
                Hp = 0;
                Task.FromResult(Die());
            }
        }

    }


    private async Task Die()
    {
        animator.SetTrigger("Dead");
        deadCount++;
        UIManager.instance.LevelText(deadCount);
        await Task.Delay(1500);
        Destroy(gameObject);
        
    }
}
