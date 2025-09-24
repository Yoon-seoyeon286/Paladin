using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<UIManager>();
            }
            return m_instance;
        }
    }

    static UIManager m_instance;

    [Header("Hp_Bar image")]
    public Image hpBarImage;



    [Header("Lv text")]
    public Text lvText;
    int updateLevel = 0;
    public int viewLevel = 1;
    int checkLevel = 5;

    [Header("Inventory")]
    public Image inventoryImage;
    public Text[] coinText;
    int totalCoin = 0;

    [Header("Power Up")]
    public Image powerUPImage;
    public int powerCoin;
    public int hpCoin;


    void Start()
    {

    }

    public void HpBar(float damage)
    {
        hpBarImage.fillAmount -= damage;
    }

    public void LevelText(int level)
    {
        updateLevel += level;
        if (updateLevel % checkLevel == 0)
        {
            viewLevel++;

            if (viewLevel % 10 == 0)
            {
                checkLevel *= 2;
            }
        }

        if (viewLevel <= 1000)
        {
            lvText.text = "Lv." + viewLevel;
        }
    }


     //인벤토리 On Off
    public void InventoryOnButton()
    {
        inventoryImage.gameObject.SetActive(true);
    }

    public void InventoryOffButton()
    {
        inventoryImage.gameObject.SetActive(false);
    }

    //Coin
    public void HasCoin(int coin)
    {
        totalCoin += coin;

        for (int i = 0; i < coinText.Length; i++)
        {
            coinText[i].text = totalCoin.ToString();
        }

    }

    //PowerUp On Off
    public void OnPowerUpButton()
    {
        powerUPImage.gameObject.SetActive(true);
    }

    public void OffPowerUpButton()
    {
        powerUPImage.gameObject.SetActive(false);
    }
}
