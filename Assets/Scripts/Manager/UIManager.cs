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
        if (updateLevel % 5 == 0)
        {
            viewLevel++;
        }

        if (viewLevel <= 1000)
        {
            lvText.text = "Lv." + viewLevel;
        }
    }
}
