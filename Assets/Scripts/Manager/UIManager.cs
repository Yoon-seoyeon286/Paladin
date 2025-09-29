using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    [Header("AudioSource")]
    public AudioSource audioSource;
    public AudioClip CoinNotEnoughSound;
    public AudioClip UIOnButton;
    public AudioClip GhachSound;
    public AudioClip setItem;
    public AudioClip dead;
 


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
    public RawImage coinNotEnough;


    [Header("Ghach")]
    public SwordGhachSystem swordGhachSystem;
    public AmorGhachSystem AmorGhachSystem;



    [Header("Power Up")]
    public Image powerUPImage;
    public int powerCoin;
    public int hpCoin;



    [Header("Shop")]
    public Image shopImage;
    public GameObject swordGachaImage;
    public GameObject amorGachaImage;
    int buyCoin = 10;


    [Header("Sword")]
    public Text[] swordSetText;
    public RawImage[] SwordcoverImage;
    public Text[] swordLevel;
    public Slider[] swordLevelSlider;
    public Text plusDamage;
    public Text plusHp;


    [Header("Amor")]
    public Text[] amorSetText;
    public RawImage[] amorCoverImage;
    public Text[] amorLevel;
    public Slider[] amorLevelSlider;


    [Header("Game over")]
    public RawImage gameOver;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


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
        audioSource.PlayOneShot(UIOnButton);
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

    //코인 부족 안내창
    public void NotEnoughCoin()
    {
        audioSource.PlayOneShot(CoinNotEnoughSound);
        coinNotEnough.gameObject.SetActive(true);
        Task.FromResult(CoinMessage());

    }

    async Task CoinMessage()
    {
        await Task.Delay(1000);
        coinNotEnough.gameObject.SetActive(false);
    }

    //[PowerUp OnOff]

    public void OnPowerUpButton()
    {
        audioSource.PlayOneShot(UIOnButton);
        powerUPImage.gameObject.SetActive(true);
    }

    public void OffPowerUpButton()
    {
        powerUPImage.gameObject.SetActive(false);
    }


    //[shop onOff]

    public void OnShopButton()
    {
        audioSource.PlayOneShot(UIOnButton);
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
           
            audioSource.PlayOneShot(GhachSound);
            Coin.instance.UseCoin(buyCoin);
            swordGachaImage.SetActive(true);
            swordGhachSystem.GhachSword();

            Invoke("SwordGachaImageOff", 2f);
        }

        else if (totalCoin < buyCoin)
        {
            NotEnoughCoin();
        }
    }

    //칼 랜덤 화면 끄기
    public void SwordGachaImageOff()
    {
        swordGachaImage.SetActive(false);
    }


    //방어구 가챠 뽑기
    public void CashAmor()
    {
        if (totalCoin >= buyCoin)
        {
       
            audioSource.PlayOneShot(GhachSound);
            Coin.instance.UseCoin(buyCoin);
            amorGachaImage.SetActive(true);
            AmorGhachSystem.GhachAmor();



            Invoke("AmorGachaImageOff", 2f);
        }

        else if (totalCoin < buyCoin)
        {
            NotEnoughCoin();
        }
    }

//가챠 끄기 방어구
    public void AmorGachaImageOff()
    {
        amorGachaImage.SetActive(false);
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
        audioSource.PlayOneShot(setItem);
        plusDamage.gameObject.SetActive(true);
        
        foreach (Text textObject in swordSetText)
        {
            textObject.gameObject.SetActive(false);
        }

        foreach (Text textObject in swordSetText)
        {
            if (textObject.name == swordName)
            {
                textObject.gameObject.SetActive(true);
                
                return;
            }

        }
    }

    //장착 시 추가 대미지 업데이트
    public void SetSwordPluseDamage(int damage)
    {
        plusDamage.text = "+" + damage.ToString();
    }


    //Sword Level 활성화 및 레벨 텍스트 업데이트
    public void SwordLevelUpdate(int level, string swordLevelName)
    {
        for (int i = 0; i < swordLevel.Length; i++)
        {
            if (swordLevel[i].name == swordLevelName)
            {
                swordLevel[i].text = level.ToString();
            }
        }

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




    //[Amor set]

    // 커버 없애기(방어구)
    public void AmoritemCover(string coverName)
    {
        foreach (RawImage itemCover in amorCoverImage)
        {
            if (itemCover.name == coverName)
            {
                itemCover.gameObject.SetActive(false);
            }
        }
    }


    //장착중 텍스트 활성화
    
        public void SetAmorTextOn(string amorName)
    {
        audioSource.PlayOneShot(setItem);
        plusHp.gameObject.SetActive(true);
        
        foreach (Text textObject in amorSetText)
        {
            textObject.gameObject.SetActive(false);
        }

        foreach (Text textObject in amorSetText)
        {
            if (textObject.name == amorName)
            {
                textObject.gameObject.SetActive(true);
                
                return;
            }

        }
    }

    //장착 시 추가 체력 ㅌ텍스트  업데이트
        public void SetAmorPlusHp(int hp)
    {

        plusHp.text = "+" + hp.ToString();
    }

    //Amor Level 활성화 및 레벨 텍스트 업데이트
     public void AmorLevelUpdate(int level, string amorLevelName)
    {
        for (int i = 0; i < amorLevel.Length; i++)
        {
            if (amorLevel[i].name == amorLevelName)
            {
                amorLevel[i].text = level.ToString();
            }
        }

    }

    // 레벨 슬라이더 조정
        public void AmorLevelSlider(int amorCount, string sliderName)
    {
        foreach (Slider levelSlider in amorLevelSlider)
        {
            if (levelSlider.name == sliderName)
            {
                levelSlider.value = amorCount;

                if (amorCount % 4 == 0)
                {
                    levelSlider.maxValue *= 2;
                }
            }
        }
    }




    //[게임 승패 관련]


    //게임 오버
    public void GameOver()
    {
        audioSource.PlayOneShot(dead);
        gameOver.gameObject.SetActive(true);
    }

    //재시작 버튼
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    //나가기
    public void OutGame()
    {
        Application.Quit();
    }
        

}
