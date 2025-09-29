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

            totalDamage += 50;
            attackNeedCoin *= 4;

            Coin.instance.UseCoin(attackNeedCoin);

            upgrgdeCoinTextInAttack.text = attackNeedCoin.ToString() + "$";
   
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

            totalHp += 50;
            hpNeedCoin *= 4;

            upgradeCoinTextInHp.text = hpNeedCoin.ToString() + "$";
            Coin.instance.UseCoin(hpNeedCoin);
     
        }

        else if (Coin.instance.totalCoin < hpNeedCoin)
        {
            UIManager.instance.NotEnoughCoin();
        }

    }

}
