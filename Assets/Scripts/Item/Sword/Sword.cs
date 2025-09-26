using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public SwordData swordData;

    /*public void SwordAttack(IDamageable damageable)
    {
        finalDamage = swordData.baseDamage;

        damageable.Damage(finalDamage);
        UIManager.instance.SetSwordPluseDamage(finalDamage);

        PlayerSwordStats stats;

        stats = InventoryManager.instance.playerSwords[swordData];
    }*/
}
