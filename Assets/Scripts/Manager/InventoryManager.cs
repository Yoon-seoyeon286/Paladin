using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager m_instance;

    public static InventoryManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<InventoryManager>();
            }
            return m_instance;
        }
    }

    public Dictionary<SwordData, PlayerSwordStats> playerSwords = new Dictionary<SwordData, PlayerSwordStats>();
    public void AddSword(SwordData swordData)
    {
        PlayerSwordStats stats;

        if (!playerSwords.ContainsKey(swordData))
        {
            stats = new PlayerSwordStats();
            playerSwords.Add(swordData, stats);
            UIManager.instance.SworditemCover(swordData.coverName);
        }

        else
        {
            stats = playerSwords[swordData];
        }

        
        stats.count++;
        UIManager.instance.SwordLevelSlider(stats.count, swordData.sliderName);

       

        if (stats.count>0 && stats.count % 2 == 0)
        {
            int currentLevel = stats.level;
            stats.level++;


            if (stats.level > currentLevel)
            {
                UIManager.instance.SwordLevelUpdate(stats.level, swordData.swordLevel);
            }
        }


    }




}
