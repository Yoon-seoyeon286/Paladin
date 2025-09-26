using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;

    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<GameManager>();
            }
            return m_instance;
        }
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
    }

}
