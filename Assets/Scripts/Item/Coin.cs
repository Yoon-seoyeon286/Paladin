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

    public int totalCoin;
    int remainCoin;

    void Start()
    {
        totalCoin = 0;
    }

    void Update()
    {
        
    }

    public void GetCoin(int count)
    {
        //레벨이 오를수록 취득하는 코인의 양이 증가
        if (UIManager.instance.viewLevel % 10 == 0)
        {
            count += 10;
        }

        int randomCoin = Random.Range(1, count);
        UIManager.instance.HasCoin(randomCoin);

        totalCoin += randomCoin;
    }

    public void UseCoin(int coin)
    {
        if (totalCoin >= coin)
        {
            totalCoin -= coin;

            UIManager.instance.UseCoin(coin);
        }

        else return;
    }

}
