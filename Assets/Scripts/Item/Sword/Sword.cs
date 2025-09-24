using UnityEngine;

public class Sword : MonoBehaviour
{
    public int TotalDamage { get; protected set; }
    public int PlusDamage { get; protected set; }
    public int SwordCount { get; protected set; }
    public int SwordLevel { get; protected set; }
    public bool SetSword { get; protected set; }

    public PlayerMove playerMove;

    void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerMove = playerObj.GetComponent<PlayerMove>();
        }

        SwordCount = 0;
        SwordLevel = 0;

        SetSword = false;
    }

    //해당 칼 착용 여부
    public virtual void OnSwordCheck()
    {
        SetSword = true;
    }

    // 칼 얻었을 때
    public virtual void GetSword()
    {
        SwordCount++;

        if (SwordCount % 2 == 0)
        {
            SwordLevel++;

        }
    }

    //추가 대미지
    public virtual void DamagePoint()
    {
        TotalDamage = 0;
        playerMove.Smash(TotalDamage);
    }

    //다른 칼 눌렀을 때
    public virtual void OffSword()
    {
        SetSword = false;
    }

}
