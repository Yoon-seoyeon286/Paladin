using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float Hp { get; private set; }

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Hp = 100;
    }

    public void Damage(float damage)
    {
        if (Hp <= 0) return;

        if (Hp > 0)
        {
            Hp -= damage;
            UIManager.instance.HpBar(damage);

            if (Hp <= 0)
            {
                Hp = 0;
                Task.FromResult(Die());
            }
        }
    }

    async Task Die()
    {
        GameManager.instance.GameOver();
        await Task.Delay(2500);
        Destroy(gameObject);
    }

  


}
