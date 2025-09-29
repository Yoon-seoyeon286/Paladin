using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager m_instance;

    public static UpgradeManager instance
    {
        get
        {
            if (m_instance == null)
            {
                FindAnyObjectByType<UpgradeManager>();
            }

            return m_instance;
        }
    }

    PlayerMove playerMove;
    PlayerHealth playerHealth;
    public SwordData equippedSword;
    public int attackNeedCoin = 10;
    public int hpNeedCoin = 10;
    private List<IDamageable> enemies = new List<IDamageable>();
    int totalDamage=0;
    float totalHp=0;

    public Text upgrgdeCoinTextInAttack;
    public Text upgradeCoinTextInHp;

    public Text upgradeAttackText;
    public Text upgradeHpText;




    public void Awake()
    {
        GameObject playObj = GameObject.FindGameObjectWithTag("Player");
        if (playObj != null)
        {
            playerHealth = playObj.GetComponent<PlayerHealth>();
            playerMove = playObj.GetComponent<PlayerMove>();
        }
    }

    public void UpgradeAttackButton()
    {

        if (Coin.instance.totalCoin >= attackNeedCoin)
        {
            foreach (IDamageable enemiesInRange in enemies)
            {
                enemiesInRange.Damage(totalDamage);
                       
            }

            upgradeAttackText.gameObject.SetActive(true);

            totalDamage += 50;
            attackNeedCoin *= 4;

            Coin.instance.UseCoin(attackNeedCoin);

            upgrgdeCoinTextInAttack.text = attackNeedCoin.ToString() + "$";
            UIManager.instance.SetSwordPluseDamage(totalDamage);
        }

        else if (Coin.instance.totalCoin < attackNeedCoin)
        {
            UIManager.instance.NotEnoughCoin();
        }
    }

    public void UpgradeHpButton()
    {
       

        if (Coin.instance.totalCoin >= hpNeedCoin)
        {
            playerHealth.UpgradeHp(totalHp);
            totalHp += 50;
            hpNeedCoin *= 4;

            upgradeHpText.gameObject.SetActive(true);

            upgradeCoinTextInHp.text = hpNeedCoin.ToString() + "$";
            Coin.instance.UseCoin(hpNeedCoin);
            UIManager.instance.SetAmorPlusHp((int)totalHp);
        }

        else if (Coin.instance.totalCoin < hpNeedCoin)
        {
            UIManager.instance.NotEnoughCoin();
        }

    }

}
