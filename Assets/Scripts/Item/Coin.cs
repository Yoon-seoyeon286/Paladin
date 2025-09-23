using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Coin instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<Coin>();
            }
            return m_instance;
        }
    }

    private static Coin m_instance;

    [Header("coin")]
    public int coinCount;


    void Start()
    {
        coinCount = 0;
    }

    public void GetCoin(int count)
    {
        int radomCoin = Random.Range(1, count);
        coinCount += radomCoin;

        UIManager.instance.HasCoin(coinCount);

    }

}
