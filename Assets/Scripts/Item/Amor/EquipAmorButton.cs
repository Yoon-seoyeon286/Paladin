using UnityEngine;

public class EquipAmorButton : MonoBehaviour
{
     public Amor amorToEquip;
    public string amorUIName;
    PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    public void OnEquipButtonOnClick()
    {
        if (playerHealth != null && amorToEquip != null)
        {
            playerHealth.EquipAmor(amorToEquip.amorData);
            UIManager.instance.SetSwordTextOn(amorUIName);
        }
    }
}
