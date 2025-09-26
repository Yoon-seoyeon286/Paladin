using UnityEngine;

[CreateAssetMenu(fileName = "AmorData", menuName = "Scriptable Objects/AmorData")]
public class AmorData : ScriptableObject
{

    public int baseHp;
    public string amorName;
    public Color baseColor;
    public Sprite amorImage;


    [Header("인벤토리 연동")]
    public string coverName;
    public string sliderName;
    public string amorLevel;
    
}
