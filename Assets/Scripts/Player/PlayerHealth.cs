using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float Hp { get; private set; }
    public AmorData equippedAmor;
    public float plusHp;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Hp = 100;
    }



    public void UpgradeHp(float plusHp)
    {
        Hp = plusHp;
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

        if (equippedAmor != null)
        {
            int amorHp = equippedAmor.baseHp;
            if (InventoryManager.instance.playerAmors.ContainsKey(equippedAmor))
            {
                PlayerAmorStats stats = InventoryManager.instance.playerAmors[equippedAmor];
                if (stats.level > 1 && stats.level % 2 == 0)
                {
                    amorHp += 10;
                }
            }

            Hp += amorHp;
            UIManager.instance.SetAmorPlusHp(amorHp);

        }
    }

    async Task Die()
    {
        GameManager.instance.GameOver();
        await Task.Delay(100);
    }

    public void EquipAmor(AmorData amorData)
    {
        equippedAmor = amorData;
    }

  


}
