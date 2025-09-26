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
            playerMove.EquipSword(swordToEquip.swordData);
            UIManager.instance.SetSwordTextOn(swordUIName);
        }
    }
}
