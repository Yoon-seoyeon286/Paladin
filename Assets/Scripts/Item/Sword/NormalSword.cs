using UnityEngine;

public class NormalSword : Sword
{

    void Awake()
    {
        SwordCount = 1;
        PlusDamage = 10;
        SetSword = false;
    }

    public override void OnSwordCheck()
    {
        SetSword = true;
        UIManager.instance.SetSwordTextOn("NormalSwordSet");
    }

    public override void GetSword()
    {
        UIManager.instance.SworditemCover("N_S_Cover");
        base.GetSword();
        UIManager.instance.SwordLevelSlider(SwordCount, "NormalSwordCount");
        UIManager.instance.SwordLevelUpdate(SwordLevel, "NormalSwordLevel");
    }

    public override void DamagePoint()
    {
        if (SetSword == true)
        {
            if (SwordLevel > 1)
            {
                PlusDamage += 5;
            }

            TotalDamage += PlusDamage;
            playerMove.Smash(TotalDamage);
        }

        else if (SetSword == false)
        {
            playerMove.Smash(0);
        }

    }

    public override void OffSword()
    {
        base.OffSword();
        UIManager.instance.SetSwordTextOff("NormalSwordSet");
    }
}
