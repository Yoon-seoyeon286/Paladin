using UnityEngine;
using UnityEngine.UI;

public class GhachManager : MonoBehaviour
{
    private static GhachManager m_instance;
    SwordData swordData;
    public RawImage[] swordLineColor;

    public static GhachManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<GhachManager>();
            }
            return m_instance;
        }
    }

    public void BaseColor()
    {
        for (int i = 0; i < swordLineColor.Length; i++)
        {
            swordLineColor[i].gameObject.SetActive(true);
            swordLineColor[i].color = swordData.baseColor;
        }

    }
    



}
