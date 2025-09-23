using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindFirstObjectByType<Coin>();
            }
            return m_instance;
        }
    }

    private static Coin m_instance;

    void Start()
    {

    }

    public void GetCoin(int count)
    {
        int randomCoin = Random.Range(1, count);
        UIManager.instance.HasCoin(randomCoin);
    }

}
