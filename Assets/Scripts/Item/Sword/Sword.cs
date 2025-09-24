using UnityEngine;

public class Sword : MonoBehaviour
{
    public int TotalDamage{ get; protected set; }
    public int PlusDamage { get; protected set; }
    public int SwordCount { get; protected set; }

    public bool SetSword{ get; protected set; }
    
    public PlayerMove playerMove;

    void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerMove = playerObj.GetComponent<PlayerMove>();
        }

        SwordCount = 0;
    }

    public virtual void DamagePoint()
    {
        TotalDamage = 0;
        playerMove.Smash(TotalDamage);
    }

}
