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
    int level;
    int updateLevel = 0;
    int viewLevel = 1;
    int checkLevel = 5;

    [Header("Inventory")]
    public Image inventoryImage;
    public Text coinText;


    void Start()
    {
        level = 0;
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


    public void InventoryOnButton()
    {
        inventoryImage.gameObject.SetActive(true);
    }

    public void InventoryOffButton()
    {
        inventoryImage.gameObject.SetActive(false);
    }

    public void HasCoin(int coin)
    {
        coinText.text = coin+""; 
    }
}
