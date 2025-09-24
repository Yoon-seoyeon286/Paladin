using UnityEngine;

public class NormalSword : Sword
{

    void Awake()
    {
        SwordCount = 1;
        PlusDamage = 10;
    }

    public override void DamagePoint()
    {
        if (SetSword == true)
        {
           TotalDamage += PlusDamage;
           playerMove.Smash(TotalDamage);     
        }


    }
}
