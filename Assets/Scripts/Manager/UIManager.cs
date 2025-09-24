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

    [Header("Shop")]
    public Image shopImage;
    public GameObject swordGachaImage;
    int buyCoin = 500;


    [Header("Sword")]
    public Text[] swordSetText;
    public RawImage[] SwordcoverImage;
    public Button[] swordUpgradeButton;
    public Text[] swordLevel;
    public Slider[] swordLevelSlider;
    int swordTotalLevel = 0;
    int swordUpgradeCoin = 150;



    //[Player]

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


    //[인벤토리 On Off]

    public void InventoryOnButton()
    {
        inventoryImage.gameObject.SetActive(true);
    }

    public void InventoryOffButton()
    {
        inventoryImage.gameObject.SetActive(false);
    }



    //[Coin]

    //현재 가지고 있는 코인
    public void HasCoin(int coin)
    {
        totalCoin += coin;

        for (int i = 0; i < coinText.Length; i++)
        {
            coinText[i].text = totalCoin.ToString();
        }

    }

    //사용한 코인을 빼기
    public void UseCoin(int coin)
    {
        totalCoin -= coin;
        for (int i = 0; i < coinText.Length; i++)
        {
            coinText[i].text = totalCoin.ToString();
        }
    }


    //[PowerUp OnOff]

    public void OnPowerUpButton()
    {
        powerUPImage.gameObject.SetActive(true);
    }

    public void OffPowerUpButton()
    {
        powerUPImage.gameObject.SetActive(false);
    }


    //[shop onOff]

    public void OnShopButton()
    {
        shopImage.gameObject.SetActive(true);
    }

    public void OffShopButton()
    {
        shopImage.gameObject.SetActive(false);
    }

    //[shop]

     //칼 상점 구매시 랜덤 뽑기 
    public void CashSword()
    {
        if (totalCoin >= buyCoin)
        {
            Coin.instance.UseCoin(buyCoin);
            swordGachaImage.SetActive(true);

            Invoke("SwordGachaImageOff", 5f);

        }
    }

     //칼 랜덤 화면 끄기
    public void SwordGachaImageOff()
    {
        swordGachaImage.SetActive(false);
    }




    //[Sword]


    //커버 없애기 (아이템 활성화)
    public void SworditemCover(string coverName)
    {
        foreach (RawImage itemCover in SwordcoverImage)
        {
            if (itemCover.name == coverName)
            {
                itemCover.gameObject.SetActive(false);
            }
        }
    }

    //장착중 텍스트 활성화
    public void SetSwordTextOn(string swordName)
    {
        foreach (Text textObject in swordSetText)
        {
            if (textObject.name == swordName)
            {
                textObject.gameObject.SetActive(true);
            }

            else return;
        }
    }

    //장착중 텍스트 비활성화
    public void SetSwordTextOff(string swordName)
    {
        foreach (Text textObject in swordSetText)
        {
            if (textObject.name == swordName)
            {
                textObject.gameObject.SetActive(false);
            }
        }
    }

    //Sword Level 활성화 및 레벨 텍스트 업데이트 및 코인 소모
    public void SwordLevelUpdate(int level, string swordLevelName)
    {

        if (level <= 1) return;

        swordTotalLevel++;

        for (int i = 0; i < swordUpgradeButton.Length; i++)
        {
            if (swordUpgradeButton[i].name == swordLevelName)
            {
                swordUpgradeButton[i].gameObject.SetActive(true);
                Coin.instance.UseCoin(swordUpgradeCoin);

                if (totalCoin >= swordUpgradeCoin)
                {
                    swordUpgradeButton[i].onClick.AddListener(() =>
                     {
                         LevelTextUpdate(swordTotalLevel, i);
                         swordUpgradeButton[i].gameObject.SetActive(false);
                     });
                }

                else return;
           
            }
        }
    }

    //실제 레벨 텍스트 업데이트 담당
    void LevelTextUpdate(int level, int index)
    {
        swordLevel[index].text = level.ToString();
    }

    // 레벨 슬라이더 조정
    public void SwordLevelSlider(int swordCount, string sliderName)
    {
        foreach (Slider levelSlider in swordLevelSlider)
        {
            if (levelSlider.name == sliderName)
            {
                levelSlider.value = swordCount;

                if (swordCount % 4 == 0)
                {
                    levelSlider.maxValue *= 2;
                }
            }
        }
    }
        

}
