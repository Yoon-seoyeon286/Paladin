using UnityEngine;

public class Sword : MonoBehaviour
{
    public SwordData swordData;

    public void SwordAttack(IDamageable damageable)
    {
        damageable.Damage(swordData.baseDamage);
        UIManager.instance.SetSwordPluseDamage(swordData.baseDamage);
    }
}
