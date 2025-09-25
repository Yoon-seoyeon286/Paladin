using UnityEngine;

public class Sword : MonoBehaviour
{
    public SwordData swordData;

    public void SwordAttack()
    {
        float damage = swordData.baseDamage;
    }
}
