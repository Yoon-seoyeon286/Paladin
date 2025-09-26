using UnityEngine;

public class EquipSwordButton : MonoBehaviour
{
    public Sword swordToEquip;
    public string swordUIName;
    PlayerMove playerMove;

    void Awake()
    {
        playerMove = FindAnyObjectByType<PlayerMove>();
    }

    public void OnEquipBuutonOnClick()
    {
        if (playerMove != null && swordToEquip != null)
        {
            playerMove.currentSword[0] = swordToEquip;
            UIManager.instance.SetSwordTextOn(swordUIName);
        }
    }
}
