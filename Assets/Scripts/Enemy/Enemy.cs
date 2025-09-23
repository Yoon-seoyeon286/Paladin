using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public float Hp = 100;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
       
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
        await Task.Delay(1500);
        Destroy(gameObject);
        
    }
}
